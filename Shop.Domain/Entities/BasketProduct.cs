using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class BasketProduct
    {
        public Basket Basket { get; set; }
        public int BasketId { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime DateOfCreated { get; set; }
    }
}
