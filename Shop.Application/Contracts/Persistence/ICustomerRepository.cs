using Shop.Application.Functions.Users.Queries.Login;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Contracts.Persistence
{
    public interface ICustomerRepository : IAsyncRepository<Customer>
    {
        Task<string> Login(LoginDto dto);
        Task<Customer> RegisterUser(User user, string password);
    }
}
