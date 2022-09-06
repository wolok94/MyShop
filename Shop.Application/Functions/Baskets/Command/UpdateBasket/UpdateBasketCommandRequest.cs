using AutoMapper;
using MediatR;
using Shop.Application.Contracts.Persistence;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Baskets.Command.UpdateBasket
{
    public class UpdateBasketCommandRequest : IRequestHandler<UpdateBasketCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Basket> _basketRepository;

        public UpdateBasketCommandRequest(IMapper mapper, IAsyncRepository <Basket> basketRepository)
        {
            _mapper = mapper;
            _basketRepository = basketRepository;
        }
        public async Task<Unit> Handle(UpdateBasketCommand request, CancellationToken cancellationToken)
        {
            var basketToUpdate = _mapper.Map<Basket>(request);
            await _basketRepository.UpdateAsync(basketToUpdate);
            return Unit.Value;
        }
    }
}
