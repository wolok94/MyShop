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
        private readonly ShopDbContext _dbContext;

        public BasketRepository(ShopDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<double> AddProductToBasket(int id, Product product, int quantity)
        {
            var basket = await GetBasket(id);

            var productToUpdate = await _dbContext.Products.AsNoTracking().FirstOrDefaultAsync(x => x.Id == product.Id);
            basket.Products.Add(productToUpdate);
            productToUpdate.InStock -= quantity;
            await _dbContext.SaveChangesAsync();

            
            var price = basket.Products.Sum(x => x.Price);
            return price;

        }
        public async Task DeleteProductFromBasket(int basketId, Product product)
        {
            var basket = await GetBasket(basketId);
            var productToDelete = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == product.Id);
            basket.Products.Remove(productToDelete);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<Basket> GetBasketById(int basketId)
        {
            var basket = await _dbContext.BasketCarts
                .AsNoTracking()
                .Include(x => x.Products)
                .ThenInclude(p => p.Category)
                .Include(u => u.User)
                .FirstOrDefaultAsync(x => x.Id == basketId);
            return basket;
        }
        private async Task<Basket> GetBasket(int id)
        {
            var basket = await _dbContext.BasketCarts
            .Include(x => x.Products)
            .FirstOrDefaultAsync(x => x.Id == id);
            return basket;
        }


    }
}
