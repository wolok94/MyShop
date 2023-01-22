using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class ProductCart
    {
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; } = 1;
        public ShoppingCart ShoppingCart { get; set; }
        public int ShoppingCartId { get; set; }
        public DateTime DateOfCreated { get; set; }

    }
}
