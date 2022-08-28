using AutoMapper;
using FluentAssertions;
using Moq;
using Shop.Application.Contracts.Persistence;
using Shop.Application.Functions.Comments.Queries.GetInList;
using Shop.Application.Mapper;
using Shop.Application.UnitTest.Helper;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.UnitTest.Comments.Queries.GetCommentsInList
{
    public class GetInListTest
    {
        private readonly IMapper _mapper;
        private readonly IMock<ICommentsRepository> _mockRepository;

        public GetInListTest()
        {
            _mockRepository = GetCommentHelper.GetMock();
            var configureProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configureProvider.CreateMapper();
        }

        [Fact]
        public async Task GetInListTest_ReturnsListOfComments()
        {
            var handler = new GetCommentsInListViewQueryHandler(_mapper, _mockRepository.Object);

            var comments = await handler.Handle(new GetCommentInListViewQuery(), CancellationToken.None);

            comments.Should().AllBeOfType(typeof(CommentsView));
            comments.Count.Should().Be(2);
        }
    }
}
