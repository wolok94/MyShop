using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Orders.UpdateOrder
{
    public class UpdateOrderCommand : IRequest
    {
        public int Id { get; set; }
        public int BasketId { get; set; }
        public int Shipment { get; set; }
        public int UserId { get; set; }
        public DateTime dateOfOrder { get; set; } = DateTime.Now;
    }
}
