using MediatR;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.BasketProducts.Command.Create
{
    public class CreateBasketProductCommand : IRequest<BasketProduct>
    {
        public int ProductId { get; set; }
        public int BasketId { get; set; }
    }
}
