using AutoMapper;
using FluentAssertions;
using Moq;
using Shop.Application.Contracts.Persistence;
using Shop.Application.Functions.Comments.Queries.GetCommentDetail;
using Shop.Application.Functions.Comments.Queries.GetInList;
using Shop.Application.Mapper;
using Shop.Application.UnitTest.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.UnitTest.Comments.Queries.GetComments
{
    public class GetCommentDetailTest
    {
        private readonly IMapper _mapper;
        private readonly IMock<ICommentsRepository> _mockRepository;

        public GetCommentDetailTest()
        {
            _mockRepository = GetCommentHelper.GetMock();
            var configureProvide = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configureProvide.CreateMapper();
        }

        [Fact]
        public async Task GetCommentDetail_ForCorrectId_ReturnComment()
        {
            var handler = new GetCommentDetailQueryHandler(_mapper, _mockRepository.Object);

            var query = new GetCommentDetailQuery()
            {
                Id = 1
            };
            var comment = await handler.Handle(query, CancellationToken.None);

            comment.Should().BeOfType(typeof(CommentsView));

        }
    }
}
