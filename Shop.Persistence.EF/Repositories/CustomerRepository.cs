using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Contracts.Persistence;
using Shop.Application.Functions.Exceptions;
using Shop.Application.Functions.Users.Commands.CreateUser;
using Shop.Application.Functions.Users.Queries.Login;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Shop.Persistence.EF.Repositories
{
    public class UserRepository : BaseRepository<Customer>, ICustomerRepository
    {

        private ShopDbContext _dbContext;
        private IPasswordHasher<Customer> _passwordHasher;
        public UserRepository(ShopDbContext dbContext, IPasswordHasher<Customer> passwordHasher) : base(dbContext)
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
        }

        public async Task<Customer> Login( LoginDto dto)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.NickName == dto.NickName);
            var result = _passwordHasher.VerifyHashedPassword((Customer)user, user.hashedPassword, dto.Password);
            if (result == Microsoft.AspNetCore.Identity.PasswordVerificationResult.Failed)
            {
                throw new NotFoundException("Wrong nickname or password");
            }
            var customer = await _dbContext.Users.FirstOrDefaultAsync(x => x.NickName == dto.NickName && result == Microsoft.AspNetCore.Identity.PasswordVerificationResult.SuccessRehashNeeded);

            return (Customer)customer;
        }
    }
}
