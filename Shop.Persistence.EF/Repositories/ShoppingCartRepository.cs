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
    public class ShoppingCartRepository : BaseRepository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly ShopDbContext _dbContext;

        public ShoppingCartRepository(ShopDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<double> AddProductToShoppingCart(int? id, Product product, int quantity)
        {
            var shoppingCart = await GetShoppingCart(id);

            var productToUpdate = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == product.Id);
            shoppingCart.Products.Add(productToUpdate);
            productToUpdate.InStock -= quantity;
            await _dbContext.SaveChangesAsync();

            
            var price = shoppingCart.Products.Sum(x => x.Price);
            return price;

        }
        public async Task DeleteProductFromShoppingCart(int shoppingCartId, Product product)
        {
            var shoppingCart = await GetShoppingCart(shoppingCartId);
            var productToDelete = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == product.Id);
            shoppingCart.Products.Remove(productToDelete);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<ShoppingCart> GetShoppingCartById(int shoppingCartId)
        {
            var shoppingCart = await _dbContext.ShoppingCarts
                .AsNoTracking()
                .Include(x => x.Products)
                .ThenInclude(p => p.Category)
                .Include(u => u.Customer)
                .FirstOrDefaultAsync(x => x.Id == shoppingCartId);
            return shoppingCart;
        }
        private async Task<ShoppingCart> GetShoppingCart(int? id)
        {
            var shoppingCart = await _dbContext.ShoppingCarts
            .Include(x => x.Products)
            .FirstOrDefaultAsync(x => x.Id == id);
            return shoppingCart;
        }


    }
}
