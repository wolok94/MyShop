using AutoMapper;
using MediatR;
using Shop.Application.Contracts.Persistence;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IAsyncRepository<Product> _repository;
        public DeleteProductCommandHandler(IMapper _mapper, IAsyncRepository<Product> repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var productToDelete = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(productToDelete);
            return Unit.Value;
        }
    }
}
