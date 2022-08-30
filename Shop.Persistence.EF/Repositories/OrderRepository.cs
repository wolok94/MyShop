using Shop.Application.Contracts.Persistence;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.EF.Repositories
{
    public class OrderRepository : BaseRepository<OrderToSend>, IOrderRepository
    {
        public OrderRepository(ShopDbContext dbContext) : base(dbContext)
        {

        }
    }
}
