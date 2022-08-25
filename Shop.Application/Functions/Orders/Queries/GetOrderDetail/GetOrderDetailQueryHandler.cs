using AutoMapper;
using MediatR;
using Shop.Application.Contracts.Persistence;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Orders.Queries.GetOrderDetail
{
    public class GetOrderDetailQueryHandler : IRequestHandler<GetOrderDetailQuery, OrderToSend>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<OrderToSend> _orderRepository;
        public GetOrderDetailQueryHandler(IMapper mapper, IAsyncRepository<OrderToSend> orderRepository)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<OrderToSend> Handle(GetOrderDetailQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.Id);
            return order;
        }
    }
}
