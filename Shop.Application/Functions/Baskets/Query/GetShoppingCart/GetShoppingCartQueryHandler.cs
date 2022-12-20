using AutoMapper;
using MediatR;
using Shop.Application.Contracts.Persistence;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Baskets.Query.GetShoppingCart
{
    public class GetShoppingCartQueryHandler : IRequestHandler<GetShoppingCartQuery, ShoppingCart>
    {
        private readonly IMapper _mapper;
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public GetShoppingCartQueryHandler(IMapper mapper, IShoppingCartRepository shoppingCartRepository)
        {
            _mapper = mapper;
            _shoppingCartRepository = shoppingCartRepository;
        }
        public async Task<ShoppingCart> Handle(GetShoppingCartQuery request, CancellationToken cancellationToken)
        {
            var shoppingCart = await _shoppingCartRepository.GetShoppingCartById();
            return shoppingCart;

        }
    }
}
