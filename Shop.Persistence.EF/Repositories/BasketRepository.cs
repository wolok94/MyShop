using Microsoft.EntityFrameworkCore;
using Shop.Application.Contracts.Persistence;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.EF.Repositories
{
    public class BasketRepository : BaseRepository<Basket>, IBasketRepository
    {


        public BasketRepository(ShopDbContext dbContext) : base(dbContext)
        {

        }


    }
}
