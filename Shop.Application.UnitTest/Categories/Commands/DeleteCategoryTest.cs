using AutoMapper;
using FluentAssertions;
using Moq;
using Shop.Application.Contracts.Persistence;
using Shop.Application.Functions.Categories.Commands.DeleteCategory;
using Shop.Application.Mapper;
using Shop.Application.UnitTest.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.UnitTest.Categories.Commands
{
    public class DeleteCategoryTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICategoryRepository> _mockRepository;

        public DeleteCategoryTest()
        {
            _mockRepository = GetCategoryRepositoryHelper.GetCategoryRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task AddAsync_ForValidModel_ReturnsId()
        {
            var handler = new DeleteCategoryCommandHandler(_mapper, _mockRepository.Object);
            var allCategoriesBeforeCount = (await _mockRepository.Object.GetAll()).Count;

            var command = new DeleteCategoryCommand()
            {
                Id = 2
            };

            await handler.Handle(command, CancellationToken.None);
            var allCategories = (await _mockRepository.Object.GetAll()).Count;

            allCategories.Should().Be(allCategoriesBeforeCount - 1);


        }
    }
}
