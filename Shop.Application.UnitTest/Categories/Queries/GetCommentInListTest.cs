using AutoMapper;
using Moq;
using Shop.Application.Contracts.Persistence;
using Shop.Application.Functions.Categories.Queries.GetCategoriesList;
using Shop.Application.Mapper;
using Shop.Application.UnitTest.Helper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.UnitTest.Categories.Queries
{
    public class GetCommentInListTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICategoryRepository> _mockRepository;

        public GetCommentInListTest()
        {
            _mockRepository = GetCategoryRepositoryHelper.GetCategoryRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task GetCommentInList_ReturnsListOfCategory()
        {
            var handler = new GetCategoryInListQueryHandler(_mapper, _mockRepository.Object);
            var categories = _mockRepository.Object.GetAll();
            var result = await handler.Handle(new GetCategoryInListQuery(), CancellationToken.None);
            result.ShouldBeOfType<List<CategoryInListViewModel>>();

        }
    }
}
