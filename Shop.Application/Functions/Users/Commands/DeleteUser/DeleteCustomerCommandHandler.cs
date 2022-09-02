using AutoMapper;
using MediatR;
using Shop.Application.Contracts.Persistence;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Users.Commands.DeleteUser
{
    public class DeleteCustomerCommandHandler : IRequest<DeleteCustomerCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Customer> _customerRepository;
        public DeleteCustomerCommandHandler(IMapper mapper, IAsyncRepository<Customer> customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }
        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var orderToDelete = await _customerRepository.GetByIdAsync(request.Id);
            await _customerRepository.DeleteAsync(orderToDelete);
            return Unit.Value;
        }
    }
}
