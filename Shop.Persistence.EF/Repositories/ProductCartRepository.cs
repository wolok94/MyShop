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
    public class ProductCartRepository : BaseRepository<ProductCart>, IProductCartRepository
    {
        private readonly ShopDbContext _dbContext;

        public ProductCartRepository(ShopDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ProductCart>> GetProductsByShoppingCartId(int shoppingCartId)
        {
            var products = await _dbContext.ProductCart.Where(x => x.ShoppingCartId== shoppingCartId).ToListAsync();

            return products;
        }
    }
}
