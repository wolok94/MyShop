using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shop.Application.Contracts.Persistence;
using Shop.Application.Functions.Exceptions;
using Shop.Application.Functions.Users.Commands.CreateUser;
using Shop.Application.Functions.Users.Queries.Login;
using Shop.Domain.Entities;
using Shop.Persistence.EF.JwtToken;
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
        private string generatedToken;

        public CustomerRepository(ShopDbContext dbContext, IPasswordHasher<Customer> passwordHasher, ITokenService tokenService, IConfiguration configuration) : base(dbContext)
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
            _configuration = configuration;
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
            if (customer != null)
            {
                generatedToken = _tokenService.BuildToken(_configuration["Jwt:Key"].ToString(), _configuration["Jwt:Issuer"].ToString(), customer);

            }
            return generatedToken;
        }
    }
}
