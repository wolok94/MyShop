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
    public class DeleteProductFromBasketCommandHandler : IRequestHandler<DeleteProductFromBasketCommand>
    {
        private readonly IMapper _mapper;
        private readonly IBasketRepository _basketRepository;

        public DeleteProductFromBasketCommandHandler(IMapper mapper, IBasketRepository basketRepository)
        {
            _mapper = mapper;
            _basketRepository = basketRepository;
        }
        public async Task<Unit> Handle(DeleteProductFromBasketCommand request, CancellationToken cancellationToken)
        {
            await _basketRepository.DeleteProductFromBasket(request.BasketId, request.Product);
            return Unit.Value;
        }
    }
}
