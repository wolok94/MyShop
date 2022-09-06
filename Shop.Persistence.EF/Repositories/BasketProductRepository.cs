using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.EF.Repositories
{
    public class BasketProductRepository : BaseRepository<BasketProduct>
    {
        public BasketProductRepository(ShopDbContext context) : base(context)
        {

        }

        
    }
}
