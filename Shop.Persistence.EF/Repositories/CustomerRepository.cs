using MediatR;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shop.Application.Contracts.Persistence;
using Shop.Application.Functions.Baskets.Command.CreateBasket;
using Shop.Application.Functions.Exceptions;
using Shop.Application.Functions.Users.Commands.CreateUser;
using Shop.Application.Functions.Users.Queries.Login;
using Shop.Domain.Entities;
using Shop.Persistence.EF.JwtToken;
using Shop.Persistence.EF.SendingEmail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Shop.Persistence.EF.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {

        private ShopDbContext _dbContext;
        private IPasswordHasher<Customer> _passwordHasher;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;
        private readonly IMediator _mediator;
        private readonly IEmail _email;
        private string generatedToken;

        public CustomerRepository(ShopDbContext dbContext, IPasswordHasher<Customer> passwordHasher, ITokenService tokenService, IConfiguration configuration, IMediator mediator, IEmail email) : base(dbContext)
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
            _configuration = configuration;
            _mediator = mediator;
            _email = email;
        }

        public async Task<string> Login( LoginDto dto)
        {
            if (string.IsNullOrEmpty(dto.NickName) || string.IsNullOrEmpty(dto.Password))
            {
                throw new AuthenticateException("Incorrect nickname or password");
            }

            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.NickName == dto.NickName);
            var result = _passwordHasher.VerifyHashedPassword((Customer)user, user.hashedPassword, dto.Password);
            if (result == Microsoft.AspNetCore.Identity.PasswordVerificationResult.Failed)
            {
                throw new NotFoundException("Incorrect nickname or password");
            }
            var customer = await _dbContext.Users.Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.NickName == dto.NickName 
                && result == Microsoft.AspNetCore.Identity.PasswordVerificationResult.Success);

            var shoppingCart = await _dbContext.ShoppingCarts.AsNoTracking().FirstOrDefaultAsync(x => x.CustomerId == customer.Id);
            if (shoppingCart == null)
            {
                shoppingCart = await _mediator.Send(new CreateCartCommand { CustomerId = customer.Id });
            }
            if (customer != null)
            {
                generatedToken = _tokenService.BuildToken(_configuration["Jwt:Key"].ToString(), _configuration["Jwt:Issuer"].ToString(), customer, shoppingCart);

            }
            return generatedToken;
        }
        public async Task<Customer> RegisterUser(User user, string password)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            var messageParams = new MessageParams(user.Email, "Rejestracja", user.NickName, await FileReader.ReadRegistrationFile(password, user.NickName));
            await _email.SendEmail(messageParams);
            return (Customer)user;
        }
    }
}
