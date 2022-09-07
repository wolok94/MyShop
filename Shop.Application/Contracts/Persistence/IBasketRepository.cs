using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Contracts.Persistence
{
    public interface IBasketRepository : IAsyncRepository<Basket>
    {
        Task<double> AddProductToBasket(int id, Product product, int quantity);
        Task DeleteProductFromBasket(int basketId, Product product);
        Task<Basket> GetBasketById(int basketId);
    }
}
