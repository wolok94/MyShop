using MediatR;
using Shop.Application.Functions.Products.Queries.GetProductDetail;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Products.GetProductDetail
{
    public class GetProductDetailQuery : IRequest<ProductViewModel>
    {
        public int Id { get; set; }
    }
}
