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

            mockRepository.Setup(x => x.DeleteAsync(It.IsAny<Comment>())).Callback<Comment>((entity) =>
            {
                comments.Remove(entity);
            });

            mockRepository.Setup(x => x.UpdateAsync(It.IsAny<Comment>())).Callback<Comment>((entity) =>
            {
                var comment = comments.FirstOrDefault(x => x.Id == entity.Id);
                comments.Remove(comment);
                comments.Add(entity);
            });

            mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                return comments.FirstOrDefault(x => x.Id == id);
            });


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
