using MediatR;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Orders.Queries.GetOrderDetail
{
    public class GetOrderDetailQuery : IRequest<OrderToSend>
    {
        public int Id { get; set; }
    }
}
