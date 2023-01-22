using MediatR;
using Shop.Application.Contracts.Persistence;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.ProductCarts.Queries.GetProductIdsByShoppingCartIds
{
    public class GetProductIdsByShoppintCartIdsQueryHandler : IRequestHandler<GetProductIdsByShoppintCartIdsQuery, List<ProductCart>>
    {
        private readonly IProductCartRepository _productCartRepository;

        public GetProductIdsByShoppintCartIdsQueryHandler(IProductCartRepository productCartRepository)
        {
            _productCartRepository = productCartRepository;
        }
        public async Task<List<ProductCart>> Handle(GetProductIdsByShoppintCartIdsQuery request, CancellationToken cancellationToken)
        {
            var id = await _productCartRepository.GetProductsByShoppingCartId(request.ShoppingCartId);
            return id;
        }
    }
}
