using AutoMapper;
using MediatR;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shop.Application.Contracts.Persistence;
using Shop.Application.Exceptions;
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
        private readonly IMapper _mapper;
        private string generatedToken;

        public CustomerRepository(ShopDbContext dbContext, IPasswordHasher<Customer> passwordHasher
            , ITokenService tokenService, IConfiguration configuration
            , IMediator mediator, IEmail email, IMapper mapper) : base(dbContext)
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
            _configuration = configuration;
            _mediator = mediator;
            _email = email;
            _mapper = mapper;
        }

        public async Task<string> Login( LoginDto dto)
        {
            if (string.IsNullOrEmpty(dto.NickName) || string.IsNullOrEmpty(dto.Password))
            {
                throw new AuthenticateException("Incorrect nickname or password");
            }

            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.NickName == dto.NickName);
            if (user == null)
            {
                throw new NotFoundException("Incorrect nickname or password");
            }
            var result = _passwordHasher.VerifyHashedPassword((Customer)user, user.hashedPassword, dto.Password);
            if (user == null || result == Microsoft.AspNetCore.Identity.PasswordVerificationResult.Failed)
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
                generatedToken = generatedToken = _tokenService.BuildToken(_configuration["Jwt:Key"].ToString(), _configuration["Jwt:Issuer"].ToString(), customer, shoppingCart);

            }
            return generatedToken;
        }
        public async Task<Customer> RegisterUser(User user, string password)
        {
            if (await IsEmailExist(user))
            {
                throw new EmailExistException("Account with this email exist");
            }
            if (await IsAddressExist(user))
            {
                user.Address = await _dbContext.Addresses.SingleOrDefaultAsync(x => x.City == user.Address.City
            && x.Street == user.Address.Street && x.HouseNumber == user.Address.HouseNumber
            && x.PostalCode == user.Address.PostalCode);
            }
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            var messageParams = new MessageParams(user.Email, "Rejestracja", user.NickName, await FileReader.ReadRegistrationFile(password, user.NickName));
            await _email.SendEmail(messageParams);
            return (Customer)user;
        }
        public async Task<LogedUserDto> GetUserByNickName(string nickName)
        {
            var user = await _dbContext.Users.OfType<Customer>()
                .AsNoTracking()
                .Include(x => x.Address)
                .Include(x => x.ShoppingCart)
                .ThenInclude(x => x.Products)
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.NickName == nickName);

            var logedUser = _mapper.Map<LogedUserDto>(user);
            return logedUser;
        }
        private async Task<bool> IsEmailExist(User user)
        {
            if (await _dbContext.Users.AnyAsync(x => x.Email == user.Email))
            {
                return true;
            }
            return false;
        }
        private async Task<bool> IsAddressExist(User user)
        {
            if (await _dbContext.Addresses.AnyAsync(x => x.City.ToLower() == user.Address.City .ToLower()
            && x.Street.ToLower() == user.Address.Street.ToLower() && x.HouseNumber.ToLower() == user.Address.HouseNumber.ToLower()
            && x.PostalCode.ToLower() == user.Address.PostalCode.ToLower()))
            {
                return true;
            }
            return false;
        }
    }
}
