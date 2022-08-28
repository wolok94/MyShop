using AutoMapper;
using FluentAssertions;
using Moq;
using Shop.Application.Contracts.Persistence;
using Shop.Application.Functions.Comments.Command.CreateComment;
using Shop.Application.Mapper;
using Shop.Application.UnitTest.Helper;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.UnitTest.Comments.Command
{
    public class CreateCommentTest
    {
        private readonly IMapper _mapper;
        private readonly IMock<ICommentsRepository> _mockRepository;

        public CreateCommentTest()
        {
            _mockRepository = GetCommentHelper.GetMock();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();
        }
        [Fact]
        public async Task AddAsync_ForValidModel_ReturnComment()
        {
            var handler = new CreateCommentCommandHandler(_mapper, _mockRepository.Object);
            var commentBeforeCount = (await _mockRepository.Object.GetAll()).Count;

            var command = new CreateCommentCommand()
            {
                Description = "Qwerty"
            };
            var response = await handler.Handle(command, CancellationToken.None);
            var allComments = (await _mockRepository.Object.GetAll()).Count;

            allComments.Should().Be(commentBeforeCount + 1);
            response.Should().BeOfType(typeof(int));
            
        }
    }
}
