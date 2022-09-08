using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Contracts.Persistence
{
    public interface IShoppingCartRepository : IAsyncRepository<ShoppingCart>
    {
        Task<double> AddProductToShoppingCart(int id, Product product, int quantity);
        Task DeleteProductFromShoppingCart(int basketId, Product product);
        Task<ShoppingCart> GetShoppingCartById(int basketId);
    }
}
