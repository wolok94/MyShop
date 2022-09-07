using AutoMapper;
using MediatR;
using Shop.Application.Contracts.Persistence;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Baskets.Command.CreateBasket
{
    public class CreateBasketCommandHandler : IRequestHandler<CreateBasketCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Basket> _basketRepository;

        public CreateBasketCommandHandler(IMapper mapper, IAsyncRepository<Basket> basketRepository)
        {
            _mapper = mapper;
            _basketRepository = basketRepository;
        }
        public async Task<int> Handle(CreateBasketCommand request, CancellationToken cancellationToken)
        {
            var basket = _mapper.Map<Basket>(request);
            await _basketRepository.AddAsync(basket);
            return basket.Id;
        }
    }
}
