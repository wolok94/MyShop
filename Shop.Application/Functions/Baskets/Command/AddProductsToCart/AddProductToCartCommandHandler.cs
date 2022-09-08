using AutoMapper;
using MediatR;
using Shop.Application.Contracts.Persistence;
using Shop.Application.Functions.Baskets.Command.CreateBasket;
using Shop.Application.Functions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Baskets.Command.AddProductsToBasket
{
    public class AddProductToCartCommandHandler : IRequestHandler<AddProductToCartCommand, double>
    {
        private readonly IMapper _mapper;
        private readonly IShoppingCartRepository _basketRepository;
        private readonly IUserContext _userContext;
        private readonly IMediator _mediator;

        public AddProductToCartCommandHandler(IMapper mapper, IShoppingCartRepository basketRepository, IUserContext userContext, IMediator mediator)
        {
            _mapper = mapper;
            _basketRepository = basketRepository;
            _userContext = userContext;
            _mediator = mediator;
        }
        public async Task<double> Handle(AddProductToCartCommand request, CancellationToken cancellationToken)
        {
            if (_userContext.GetShoppingCartId == 0)
            {
                request.ShoppingCartId = await _mediator.Send(new CreateCartCommand { UserId = _userContext.GetUserId });
                
            }
            var ShoppingCartId = request.ShoppingCartId;
            var product = request.Product;
            var quantity = request.Quantity;
            var price = await _basketRepository.AddProductToShoppingCart(ShoppingCartId, product, quantity);
            return price;
        }
    }
}
