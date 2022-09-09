using AutoMapper;
using MediatR;
using Shop.Application.Contracts.Persistence;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Baskets.Query.GetDetailBasket
{
    public class GetDetailCartQueryHandler : IRequestHandler<GetDetailCartQuery, GetDetailCartView>
    {
        private readonly IMapper _mapper;
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public GetDetailCartQueryHandler(IMapper mapper, IShoppingCartRepository shoppingCartRepository)
        {
            _mapper = mapper;
            _shoppingCartRepository = shoppingCartRepository;
        }
        public async Task<GetDetailCartView> Handle(GetDetailCartQuery request, CancellationToken cancellationToken)
        {
            var shoppingCart = await _shoppingCartRepository.GetShoppingCartById(request.Id);
            var mappedBasket = _mapper.Map<GetDetailCartView>(shoppingCart);
            return mappedBasket;
        }
    }
}
