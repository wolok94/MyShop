using MediatR;
using Shop.Application.Functions.Users.Queries.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Users.Queries.GetUserDetail
{
    public class GetCustomerDetailQuery : IRequest<LogedUserDto>
    {
        public string Nickname { get; set; }
    }
}
