using MediatR;
using Shop.Application.Functions.Categories.Queries.GetCategoriesList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Categories.Queries.GetCategoryDetail
{
    public class GetCategoryDetailsQuery : IRequest<CategoryViewModel>
    {
        public int Id { get; set; }
    }
}
