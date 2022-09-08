using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class Customer : User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<OrderToSend> Orders { get; set; }
        public ShoppingCart ShoppingCart { get; set; }


    }
}
