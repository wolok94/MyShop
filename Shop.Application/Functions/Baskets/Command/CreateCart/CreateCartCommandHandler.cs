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
    public class CreateCartCommandHandler : IRequestHandler<CreateCartCommand, ShoppingCart>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<ShoppingCart> _shoppingCartRepository;

        public CreateCartCommandHandler(IMapper mapper, IAsyncRepository<ShoppingCart> shoppingCartRepository)
        {
            _mapper = mapper;
            _shoppingCartRepository = shoppingCartRepository;
        }
        public async Task<ShoppingCart> Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
            var basket = _mapper.Map<ShoppingCart>(request);
            await _shoppingCartRepository.AddAsync(basket);
            return basket;
        }
    }
}
