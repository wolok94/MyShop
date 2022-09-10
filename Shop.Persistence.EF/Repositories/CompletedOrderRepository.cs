using Shop.Application.Contracts.Persistence;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.EF.Repositories
{
    public class CompletedOrderRepository : BaseRepository<CompletedOrder>, ICompletedOrderRepository
    {
        public CompletedOrderRepository(ShopDbContext dbContext) : base(dbContext)
        {

        }
    }
}
