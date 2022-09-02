using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Users.Commands.DeleteUser
{
    public class DeleteCustomerCommand : IRequest
    {
        public int Id { get; set; }
    }
}
