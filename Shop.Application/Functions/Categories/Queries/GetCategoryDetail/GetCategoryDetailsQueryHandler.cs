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
    private readonly ICategoryRepository _repository;
    public GetCategoryDetailsQueryHandler(IMapper mapper, ICategoryRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }
    public async Task<CategoryViewModel> Handle(GetCategoryDetailsQuery request, CancellationToken cancellationToken)
    {
        var category = await _repository.GetCategoryById(request.Id);
        return category;
    }
}
