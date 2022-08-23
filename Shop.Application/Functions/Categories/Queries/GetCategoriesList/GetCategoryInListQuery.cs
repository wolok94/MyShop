using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Application.Functions.Categories.Queries.GetCategoryDetail;

namespace Shop.Application.Functions.Categories.Queries.GetCategoriesList
{
    public class GetCategoryInListQuery : IRequest<List<CategoryInListViewModel>>
    {

    }
}
