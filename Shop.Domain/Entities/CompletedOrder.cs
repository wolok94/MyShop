using Shop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class CompletedOrder
    {
        public int Id { get; set; }
        public List<Product> Products { get; set; }
        public Shipment Shipment { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public int Price { get; set; }
    }
}
