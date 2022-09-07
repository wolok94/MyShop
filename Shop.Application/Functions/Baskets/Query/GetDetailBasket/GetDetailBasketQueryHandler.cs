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
    public class GetDetailBasketQueryHandler : IRequestHandler<GetDetailBasketQuery, GetDetailBasketView>
    {
        private readonly IMapper _mapper;
        private readonly IBasketRepository _basketRepository;

        public GetDetailBasketQueryHandler(IMapper mapper, IBasketRepository basketRepository)
        {
            _mapper = mapper;
            _basketRepository = basketRepository;
        }
        public async Task<GetDetailBasketView> Handle(GetDetailBasketQuery request, CancellationToken cancellationToken)
        {
            var basket = await _basketRepository.GetBasketById(request.Id);
            var mappedBasket = _mapper.Map<GetDetailBasketView>(basket);
            return mappedBasket;
        }
    }
}
