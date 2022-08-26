using Moq;
using Shop.Application.Contracts.Persistence;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.UnitTest.Helper
{
    public class GetCategoryRepositoryHelper
    {
        public static Mock<ICategoryRepository> GetCategoryRepository()
        {
            var categories = GetCategories();
            var mockCategoryRepository = new Mock<ICategoryRepository>();
            mockCategoryRepository.Setup(c => c.GetAll()).ReturnsAsync(categories);


            mockCategoryRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                {
                    var category = categories.FirstOrDefault(x => x.Id == id);
                    return category;
                }
            });

            mockCategoryRepository.Setup(c => c.AddAsync(It.IsAny<Category>())).ReturnsAsync((Category cat) => {
                categories.Add(cat);
                return cat;
            });

            mockCategoryRepository.Setup(c => c.UpdateAsync(It.IsAny<Category>()))
                .Callback<Category>((entity) => 
                { categories.Remove(entity); 
                categories.Add(entity); });

            mockCategoryRepository.Setup(c => c.DeleteAsync(It.IsAny<Category>()))
                .Callback<Category>((entity) => { categories.Remove(entity); });

            return mockCategoryRepository;
        }
        public static List<Category> GetCategories()
        {
           var categories =  new List<Category>
            {
                new Category
                {
                    Name = "Asdf",
                    Id =1
                },
                new Category
                {
                    Name = "Sdfg",
                    Id = 2
                }
            };
            return categories;
        }
    }
}
