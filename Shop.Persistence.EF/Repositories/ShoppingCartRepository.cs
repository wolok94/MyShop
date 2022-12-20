using Microsoft.EntityFrameworkCore;
using Shop.Application.Contracts.Persistence;
using Shop.Application.UsersContext;
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
        private readonly IUserContext _userContext;

        public ShoppingCartRepository(ShopDbContext dbContext, IUserContext userContext) : base(dbContext)
        {
            _dbContext = dbContext;
            _userContext = userContext;
        }

        public async Task<double> AddProductToShoppingCart(Product product, int quantity)
        {
            var shoppingCart = await GetShoppingCart();

            var productToUpdate = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == product.Id);
            shoppingCart.Products.Add(productToUpdate);
            productToUpdate.InStock -= quantity;
            await _dbContext.SaveChangesAsync();

            
            var price = shoppingCart.Products.Sum(x => x.Price);
            return price;

        }
        public async Task DeleteProductFromShoppingCart(int shoppingCartId, Product product)
        {
            var shoppingCart = await GetShoppingCart();
            var productToDelete = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == product.Id);
            shoppingCart.Products.Remove(productToDelete);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<ShoppingCart> GetShoppingCartById()
        {
            var shoppingCartId = _userContext.GetShoppingCartId;
            var shoppingCart = await _dbContext.ShoppingCarts
                .Include(x => x.Products)
                .ThenInclude(p => p.Category)
                .Include(u => u.Customer)
                .FirstOrDefaultAsync(x => x.Id == shoppingCartId);
            return shoppingCart;
        }
        private async Task<ShoppingCart> GetShoppingCart()
        {
            var id = _userContext.GetShoppingCartId;
            var shoppingCart = await _dbContext.ShoppingCarts
            .Include(x => x.Products)
            .FirstOrDefaultAsync(x => x.Id == id);
            return shoppingCart;
        }
        public async Task DeleteProductsFromShoppingCart(int shoppingCartId)
        {
            var shoppingCart = await GetShoppingCart();
            shoppingCart.Products.Clear();
            await _dbContext.SaveChangesAsync();

        }


    }
}
