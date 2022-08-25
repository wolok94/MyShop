using AutoMapper;
using MediatR;
using Shop.Application.Contracts.Persistence;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Product> _productRepository;
        public UpdateProductCommandHandler(IMapper mapper, IAsyncRepository<Product> repository)
        {
            _mapper = mapper;
            _productRepository = repository;
        }
        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var productToUpdate = _mapper.Map<Product>(request);
            await _productRepository.UpdateAsync(productToUpdate);
            return Unit.Value;
        }
    }
}
