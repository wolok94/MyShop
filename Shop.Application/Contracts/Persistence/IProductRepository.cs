using Shop.Domain.Entities;
using Shop.Persistence.EF.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Contracts.Persistence
{
    public interface IProductRepository : IAsyncRepository<Product>
    {
        Task<Product> GetProductDetailById(int id);
        Task<PagedResult<Product>> GetProducts(ProductQuery productQuery);
    }
}
