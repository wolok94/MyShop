using AutoMapper;
using MediatR;
using Shop.Application.Contracts.Persistence;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Orders.Command.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<OrderToSend> _orderRepository;
        public DeleteOrderCommandHandler(IMapper mapper, IAsyncRepository<OrderToSend> orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }
        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var orderToDelete = await _orderRepository.GetByIdAsync(request.Id);
            await _orderRepository.DeleteAsync(orderToDelete);
            return Unit.Value;
        }
    }
}
