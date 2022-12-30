using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Contracts.Persistence;
using Shop.Domain.Entities;
using Shop.Persistence.EF.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.EF.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly ShopDbContext _dbContext;

        public ProductRepository(ShopDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> GetProductDetailById(int id)
        {
            var product = await _dbContext.Products
                .AsNoTracking()
                .Include(x => x.Comments)
                .ThenInclude(x => x.User)
                .Select(x => new {x.Id, x.Title, x.Description, x.ImageUrl, x.Comments, x.Price})
                .FirstOrDefaultAsync(x => x.Id == id);

            var mappedProduct = new Product
            {
                Id = product.Id,
                Title = product.Title,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Comments = product.Comments,
                Price = product.Price

            };
            return mappedProduct;
        }
        public async Task <PagedResult<Product>> GetProducts(ProductQuery productQuery)
        {
            var basicQuery = _dbContext.Products
                .Where(p => productQuery.SearchPhrase == null 
                || (p.Title.ToLower().Contains(productQuery.SearchPhrase.ToLower()))
                || p.Description.ToLower().Contains(productQuery.SearchPhrase.ToLower()));

            if (!string.IsNullOrEmpty(productQuery.SortBy))
            {
                var columnsSelector = new Dictionary<string, Expression<Func<Product, object>>>
                {
                    { nameof (Product.Title), p => p.Title },
                    { nameof (Product.Description), p => p.Description }
                };
                var selectedColumn = columnsSelector[productQuery.SortBy];
                basicQuery = productQuery.SortDirection == SortDirection.ASC ?
    basicQuery.OrderBy(selectedColumn) : basicQuery.OrderByDescending(selectedColumn);
            }


            var products = await basicQuery
                .Skip(productQuery.PageSize * (productQuery.PageNumber - 1))
                .Take(productQuery.PageSize)
                .ToListAsync();

            
            var resultProducts = new PagedResult<Product>(products, products.Count(), productQuery.PageSize, productQuery.PageNumber);

            return resultProducts;
                
        }
    }
}
