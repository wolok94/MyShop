using AutoMapper;
using FluentAssertions;
using Moq;
using Shop.Application.Contracts.Persistence;
using Shop.Application.Functions.Comments.Command.DeleteComment;
using Shop.Application.Mapper;
using Shop.Application.UnitTest.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.UnitTest.Comments.Command
{
    public class DeleteCommentTest
    {
        private readonly IMapper _mapper;
        private readonly IMock<ICommentsRepository> _mockRepository;

        public DeleteCommentTest()
        {
            _mockRepository = GetCommentHelper.GetMock();
            var configuratorProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configuratorProvider.CreateMapper();
        }

        [Fact]
        public async Task DeleteAsync_ForCorrectModel_ReturnOneLessNumberOfComments()
        {
            var commentsBeforeCount = (await _mockRepository.Object.GetAll()).Count;
            var handler = new DeleteCommentCommandHandler(_mapper, _mockRepository.Object);
            var command = new DeleteCommentCommand()
            {
                Id = 1
            };
            var response = await handler.Handle(command, CancellationToken.None);
            var allComments = (await _mockRepository.Object.GetAll()).Count;
            var comments = await _mockRepository.Object.GetAll();
            var comment = comments.FirstOrDefault(x => x.Id == 1);
            allComments.Should().Be(commentsBeforeCount - 1);
            comment.Should().BeNull();
        }
    }
}
