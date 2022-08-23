using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Categories.Queries.GetCategoryDetail
{
    public class CategoryViewModel
    {
        public class CategoryInListViewModel
        {
            public int CategoryId { get; set; }
            public string Name { get; set; }
            public ICollection<Product> Products { get; set; }
        }
    }
}
