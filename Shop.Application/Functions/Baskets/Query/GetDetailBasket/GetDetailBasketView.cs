using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Baskets.Query.GetDetailBasket
{
    public class GetDetailBasketView
    {
        public int Id { get; set; }
        public List<ProductView> Products { get; set; } = new List<ProductView>();
        public string NickName { get; set; }
        public int UserId { get; set; }
    }
}
