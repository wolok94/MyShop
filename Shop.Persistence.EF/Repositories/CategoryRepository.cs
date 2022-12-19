using Microsoft.EntityFrameworkCore;
using Shop.Application.Contracts.Persistence;
using Shop.Application.Functions.Categories.Queries.GetCategoriesList;
using Shop.Application.Functions.Categories.Queries.GetCategoryDetail;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.EF.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly ShopDbContext _dbContext;

        public CategoryRepository(ShopDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CategoryViewModel> GetCategoryById(int id)
        {
            var category = await _dbContext.Categories.Include(c => c.Products)
                .Select(x => new CategoryViewModel
            {
                CategoryId = x.Id,
                Name = x.Name,
                Products = x.Products
            })
                .FirstOrDefaultAsync(c => c.CategoryId == id);

            return category;

        }

        public async Task<IList<CategoryInListViewModel>> GetCategories()
        {
            return await _dbContext.Categories.Select(x => new CategoryInListViewModel
            {
                CategoryId = x.Id,
                Name = x.Name,
            }).ToListAsync();
        }
    }
}
