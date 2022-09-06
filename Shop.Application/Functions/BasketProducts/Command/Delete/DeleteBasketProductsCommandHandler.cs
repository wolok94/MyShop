using AutoMapper;
using MediatR;
using Shop.Application.Contracts.Persistence;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.BasketProducts.Command.Update
{
    public class DeleteBasketProductsCommandHandler : IRequestHandler<DeleteBasketProductsCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<BasketProduct> _repository;

        public DeleteBasketProductsCommandHandler(IMapper mapper, IAsyncRepository<BasketProduct> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<Unit> Handle(DeleteBasketProductsCommand request, CancellationToken cancellationToken)
        {
            var basketProduct = _mapper.Map<BasketProduct>(request);
            await _repository.DeleteAsync(basketProduct);
            return Unit.Value;
        }
    }
}
