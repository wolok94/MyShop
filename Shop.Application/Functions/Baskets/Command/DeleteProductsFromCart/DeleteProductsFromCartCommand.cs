using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Baskets.Command.DeleteProductsFromCart
{
    public class DeleteProductsFromCartCommand : IRequest
    {
        public int ShoppingCartId { get; set; }
    }
}
