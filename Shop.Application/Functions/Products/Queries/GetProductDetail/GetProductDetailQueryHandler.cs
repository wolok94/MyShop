using AutoMapper;
using MediatR;
using Shop.Application.Contracts.Persistence;
using Shop.Application.Functions.Products.Queries.GetProductDetail;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Products.GetProductDetail
{
    public class GetProductDetailQueryHandler : IRequestHandler<GetProductDetailQuery, ProductViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repository;
        public GetProductDetailQueryHandler(IMapper mapper, IProductRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<ProductViewModel> Handle(GetProductDetailQuery request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetProductDetailById(request.Id);
            var mappedProduct = _mapper.Map<ProductViewModel>(product);
            return mappedProduct;

        }
    }
}
