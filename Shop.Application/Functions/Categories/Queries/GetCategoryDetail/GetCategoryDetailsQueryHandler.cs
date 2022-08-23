using AutoMapper;
using MediatR;
using Shop.Application.Contracts.Persistence;
using Shop.Application.Functions.Categories.Queries.GetCategoriesList;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Categories.Queries.GetCategoryDetail;

public class GetCategoryDetailsQueryHandler : IRequestHandler<GetCategoryDetailsQuery, CategoryViewModel>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Category> _repository;
    public GetCategoryDetailsQueryHandler(IMapper mapper, IAsyncRepository<Category> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }
    public Task<CategoryViewModel> Handle(GetCategoryDetailsQuery request, CancellationToken cancellationToken)
    {
        var category = _repository.GetByIdAsync(request.Id);
        var mappedCategory = _mapper.Map<CategoryViewModel>(category);
        return Task.FromResult(mappedCategory);
    }
}
