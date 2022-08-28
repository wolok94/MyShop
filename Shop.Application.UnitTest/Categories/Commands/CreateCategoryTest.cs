using AutoMapper;
using FluentAssertions;
using Moq;
using Shop.Application.Contracts.Persistence;
using Shop.Application.Functions.Categories.Commands.CreateCategory;
using Shop.Application.Functions.Comments.Command.CreateComment;
using Shop.Application.Mapper;
using Shop.Application.UnitTest.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.UnitTest.Categories.Commands
{
    public class CreateCategoryTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICategoryRepository> _mockRepository;

        public CreateCategoryTest()
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
            var handler = new CreateCategoryCommandHandler(_mapper, _mockRepository.Object);
            var allCategoriesBeforeCount = (await _mockRepository.Object.GetAll()).Count;

            var command = new CreateCategoryCommand()
            {
                Name = "Hjkl",

            };
            var response = await handler.Handle(command, CancellationToken.None);
            var allCategories = (await _mockRepository.Object.GetAll()).Count;

            allCategories.Should().Be(allCategoriesBeforeCount + 1);

        }
    }
}
