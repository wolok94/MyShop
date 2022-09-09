using MediatR;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Baskets.Command.CreateBasket
{
    public class CreateCartCommand : IRequest<ShoppingCart>
    {
        public int? CustomerId { get; set; }
    }
}
