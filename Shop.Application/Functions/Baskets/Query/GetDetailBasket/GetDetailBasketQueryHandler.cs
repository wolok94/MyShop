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
    public class GetDetailBasketQueryHandler : IRequestHandler<GetDetailBasketQuery, BasketProduct>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<BasketProduct> _basketProductRepository;

        public GetDetailBasketQueryHandler(IMapper mapper, IAsyncRepository<BasketProduct> basketProductRepository)
        {
            _mapper = mapper;
            _basketProductRepository = basketProductRepository;
        }
        public async Task<BasketProduct> Handle(GetDetailBasketQuery request, CancellationToken cancellationToken)
        {
            var basket = await _basketProductRepository.GetByIdAsync(request.Id);
            return basket;
        }
    }
}
