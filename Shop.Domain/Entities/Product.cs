using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int HowManyTimesOrdered { get; set; }
        public int InStock { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public List<Comment> Comments { get; set; }
        public List<ShoppingCart> ShoppingCarts { get; set; }
        public List<OrderToSend> Orders { get; set; }
        public string ImageUrl { get; set; }
        

    }
}
