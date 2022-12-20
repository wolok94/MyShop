using AutoMapper;
using MediatR;
using Shop.Application.Contracts.Persistence;
using Shop.Application.Functions.Categories.Queries.GetCategoryDetail;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Categories.Queries.GetCategoriesList
{
    public class GetCategoryInListQueryHandler : IRequestHandler<GetCategoryInListQuery, List<CategoryInListViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _repository;
        public GetCategoryInListQueryHandler(IMapper mapper, ICategoryRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<List<CategoryInListViewModel>> Handle(GetCategoryInListQuery request, CancellationToken cancellationToken)
        {
            var categories = await _repository.GetCategories();
            var ordered = categories.OrderBy(x => x.Name);
            return _mapper.Map<List<CategoryInListViewModel>>(ordered);
        }
    }
}
