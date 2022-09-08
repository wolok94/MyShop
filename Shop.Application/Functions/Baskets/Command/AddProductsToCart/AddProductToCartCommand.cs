using MediatR;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Baskets.Command.AddProductsToBasket
{
    public class AddProductToCartCommand : IRequest<double>
    {
        public int ShoppingCartId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
