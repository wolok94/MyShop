using AutoMapper;
using FluentAssertions;
using Moq;
using Shop.Application.Contracts.Persistence;
using Shop.Application.Functions.Comments.Command.UpdateComment;
using Shop.Application.Mapper;
using Shop.Application.UnitTest.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.UnitTest.Comments.Command
{
    public class UpdateCommentsTest
    {
        private readonly IMapper _mapper;
        private readonly IMock<ICommentsRepository> _mockRepository;

        public UpdateCommentsTest()
        {
            _mockRepository = GetCommentHelper.GetMock();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task UpdateAsync_ForValidModel_ReturnModifiedComment()
        {
            var handler = new UpdateCommentCommandHandler(_mapper, _mockRepository.Object);
            var command = new UpdateCommentCommand()
            {
                Description = "Test",
                Id = 1
            };
            var response = await handler.Handle(command, CancellationToken.None);
            var comments = await _mockRepository.Object.GetAll();

            var comment = comments.FirstOrDefault(x => x.Id == 1);
            comment.Description.Should().Be("Test");


        }
    }
}
