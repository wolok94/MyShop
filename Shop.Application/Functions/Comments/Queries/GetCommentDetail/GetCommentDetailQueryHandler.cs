using AutoMapper;
using MediatR;
using Shop.Application.Contracts.Persistence;
using Shop.Application.Functions.Comments.Queries.GetInList;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Comments.Queries.GetCommentDetail
{
    public class GetCommentDetailQueryHandler : IRequestHandler<GetCommentDetailQuery, CommentsView>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Comment> _commentRepository;
        public GetCommentDetailQueryHandler(IMapper mapper, IAsyncRepository<Comment> commentRepository)
        {
            _mapper = mapper;
            _commentRepository = commentRepository;
        }
        public async Task<CommentsView> Handle(GetCommentDetailQuery request, CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.GetByIdAsync(request.Id);
            return _mapper.Map<CommentsView>(comment);
        }
    }
}
