using AutoMapper;
using MediatR;
using Shop.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Baskets.Command.DeleteProductsFromCart
{
    public class DeleteProductsFromCartCommandHandler : IRequestHandler<DeleteProductsFromCartCommand>
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public DeleteProductsFromCartCommandHandler(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }
        public async Task<Unit> Handle(DeleteProductsFromCartCommand request, CancellationToken cancellationToken)
        {
            await _shoppingCartRepository.DeleteProductsFromShoppingCart(request.ShoppingCartId);
            return Unit.Value;
        }
    }
}
