using MediatR;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Users.Queries.Login
{
    public class LoginCustomerQuery : IRequest<Customer>
    {
        public string NickName { get; set; }
        public string Password { get; set; }
    }
}
