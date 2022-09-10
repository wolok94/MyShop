using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class OrderProduct
    {
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public CompletedOrder Order { get; set; }
        public int OrderId { get; set; }
    }
}
