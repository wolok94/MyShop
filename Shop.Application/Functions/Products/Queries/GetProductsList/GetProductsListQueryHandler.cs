using AutoMapper;
using MediatR;
using Shop.Application.Contracts.Persistence;
using Shop.Application.Functions.Products.Queries.GetProductsList;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Products.GetProductsList
{
    public class GetPostsListQueryHandler : IRequestHandler<GetProductsListQuery, List<ProductInListViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Product> _postRepository;

        public GetPostsListQueryHandler(IMapper mapper, IAsyncRepository<Product> postRepository)
        {
            _mapper = mapper;
            _postRepository = postRepository;
        }
        public async Task<List<ProductInListViewModel>> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
        {
            var all = await _postRepository.GetAll();
            var allOrdered = all.OrderBy(x => x.Title);

            return _mapper.Map<List<ProductInListViewModel>>(allOrdered);
        }
    }
}
