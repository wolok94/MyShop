using AutoMapper;
using MediatR;
using Shop.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Baskets.Command.DeleteProductFromBasket
{
    public class DeleteProductFromCartCommandHandler : IRequestHandler<DeleteProductFromCartCommand>
    {
        private readonly IMapper _mapper;
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public DeleteProductFromCartCommandHandler(IMapper mapper, IShoppingCartRepository shoppingCartRepository)
        {
            _mapper = mapper;
            _shoppingCartRepository = shoppingCartRepository;
        }
        public async Task<Unit> Handle(DeleteProductFromCartCommand request, CancellationToken cancellationToken)
        {
            await _shoppingCartRepository.DeleteProductFromShoppingCart(request.ShoppingCartId, request.Product);
            return Unit.Value;
        }
    }
}
