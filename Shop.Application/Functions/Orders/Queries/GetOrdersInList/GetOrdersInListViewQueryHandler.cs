using MediatR;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Application.Functions.Order.Queries.GetOrdersInList;
using Shop.Application.Contracts.Persistence;
using AutoMapper;

namespace Shop.Application.Functions.Orders.Queries.GetOrdersInList;

public class GetOrdersInListViewQueryHandler : IRequestHandler<GetOrdersInListViewQuery, List<OrderToSend>>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<OrderToSend> _orderRepository;
    public GetOrdersInListViewQueryHandler(IMapper mapper, IAsyncRepository<OrderToSend> orderRepository)
    {
        _mapper = mapper;
        _orderRepository = orderRepository;
    }
    public async Task<List<OrderToSend>> Handle(GetOrdersInListViewQuery request, CancellationToken cancellationToken)
    {
        var orders = await _orderRepository.GetAll();
        var orderedOrders = orders.OrderBy(o => o.isDelivered);
        return _mapper.Map<List<OrderToSend>>(orderedOrders);
    }
}
