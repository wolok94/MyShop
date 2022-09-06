using AutoMapper;
using MediatR;
using Shop.Application.Contracts.Persistence;
using Shop.Application.Functions.Categories.Commands.CreateCategory;
using Shop.Application.Functions.Exceptions;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IAsyncRepository<Product> _repository;
        private readonly IMapper _mapper;
        public CreateProductCommandHandler(IMapper mapper,IAsyncRepository<Product> repository)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreatedProductCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid)
            {
                throw new ValidationShopException(validatorResult);
            }
            var product = _mapper.Map<Product>(request);
            product = await _repository.AddAsync(product);
            return product.Id;
        }
    }
}
