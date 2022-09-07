using AutoMapper;
using MediatR;
using Shop.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Baskets.Command.AddProductsToBasket
{
    public class AddProductToBasketCommandHandler : IRequestHandler<AddProductToBasketCommand, double>
    {
        private readonly IMapper _mapper;
        private readonly IBasketRepository _basketRepository;

        public AddProductToBasketCommandHandler(IMapper mapper, IBasketRepository basketRepository)
        {
            _mapper = mapper;
            _basketRepository = basketRepository;
        }
        public async Task<double> Handle(AddProductToBasketCommand request, CancellationToken cancellationToken)
        {
            var basketId = request.BasketId;
            var product = request.Product;
            var quantity = request.Quantity;
            var price = await _basketRepository.AddProductToBasket(basketId, product, quantity);
            return price;
        }
    }
}
