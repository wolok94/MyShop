using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.BasketProducts.Command.Update
{
    public class DeleteBasketProductsCommand : IRequest
    {
        public int ProductId { get; set; }
        public int BasketId { get; set; }
    }
}
