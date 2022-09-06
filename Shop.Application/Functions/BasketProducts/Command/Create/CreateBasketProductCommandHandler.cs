using AutoMapper;
using MediatR;
using Shop.Application.Contracts.Persistence;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.BasketProducts.Command.Create
{
    public class CreateBasketProductCommandHandler : IRequestHandler<CreateBasketProductCommand, BasketProduct>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<BasketProduct> _repository;

        public CreateBasketProductCommandHandler(IMapper mapper, IAsyncRepository<BasketProduct> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<BasketProduct> Handle(CreateBasketProductCommand request, CancellationToken cancellationToken)
        {
            var basketProduct = _mapper.Map<BasketProduct>(request);
            var createdBasketProduct = await _repository.AddAsync(basketProduct);
            return createdBasketProduct;
        }
    }
}
