using MediatR;
using Shop.Application.Functions.Products.Queries.GetProductsList;
using Shop.Domain.Entities;
using Shop.Persistence.EF.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Products.GetProductsList
{
    public class GetProductsListQuery : IRequest<PagedResult<Product>>
    {
        public ProductQuery ProductQuery { get; set; }
    }
}
