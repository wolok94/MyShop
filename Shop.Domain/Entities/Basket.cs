using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class Basket
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
