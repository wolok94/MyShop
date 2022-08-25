using AutoMapper;
using MediatR;
using Shop.Application.Contracts.Persistence;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Comments.Queries.GetInList
{
    public class GetCommentsInListViewQueryHandler : IRequestHandler<GetCommentInListViewQuery, List<CommentsView>
    {
        private readonly IMapper _mapper;
        private IAsyncRepository<Comment> _commentRepository;
        public GetCommentsInListViewQueryHandler(IMapper mapper, IAsyncRepository<Comment> commentRepository)
        {
            _mapper = mapper;
            _commentRepository = commentRepository;
        }

        public async Task<List<CommentsView>> Handle(GetCommentInListViewQuery request, CancellationToken cancellationToken)
        {
            var comments = await _commentRepository.GetAll();
            var orderedComments = comments.OrderBy(u => u.CreatedDate);
            return _mapper.Map<List<CommentsView>>(orderedComments);
        }
    }
}
