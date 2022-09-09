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

        public AddProductToCartCommandHandler(IMapper mapper, IShoppingCartRepository basketRepository, IUserContext userContext)
        {
            _mapper = mapper;
            _basketRepository = basketRepository;
            _userContext = userContext;
        }
        public async Task<double> Handle(AddProductToCartCommand request, CancellationToken cancellationToken)
        {
            var ShoppingCartId = _userContext.GetShoppingCartId;
            var product = request.Product;
            var quantity = request.Quantity;
            var price = await _basketRepository.AddProductToShoppingCart(ShoppingCartId, product, quantity);
            return price;
        }
    }
}
