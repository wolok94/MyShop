using Moq;
using Shop.Application.Contracts.Persistence;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.UnitTest.Helper
{
    public static class GetCommentHelper 
    {
        public static IMock<ICommentsRepository> GetMock()
        {
            var comments = GetComments();
            var mockRepository = new Mock<ICommentsRepository>();

            mockRepository.Setup(x => x.AddAsync(It.IsAny<Comment>())).ReturnsAsync((Comment comment) =>
            {
                comments.Add(comment);
                return comment;
            });

            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(comments);

            return mockRepository;
        }

        public static List<Comment> GetComments()
        {
            var comments = new List<Comment>()
            {
                new Comment()
                {
                    Description = "Asdf",
                    Id =1
                },
                new Comment()
                {
                    Description = "SDFG",
                    Id =2
                }
            };
            return comments;
        }
    }
}
