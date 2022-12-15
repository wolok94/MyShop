using AutoMapper;
using MediatR;
using Shop.Application.Contracts.Persistence;
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
    public class GetPostsListQueryHandler : IRequestHandler<GetProductsListQuery, PagedResult<Product>>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public GetPostsListQueryHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public async Task<PagedResult<Product>> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
        {
            var all = await _productRepository.GetProducts(request.ProductQuery);

            return _mapper.Map<PagedResult<Product>>(all);
        }
    }
}
