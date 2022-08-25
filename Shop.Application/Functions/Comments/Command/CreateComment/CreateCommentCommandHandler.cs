using AutoMapper;
using MediatR;
using Shop.Application.Contracts.Persistence;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Comments.Command.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Comment> _commentRepository;
        public CreateCommentCommandHandler(IMapper mapper, IAsyncRepository<Comment> commentRepository)
        {
            _mapper = mapper;
            _commentRepository = commentRepository;
        }
        public async Task<int> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = _mapper.Map<Comment>(request);
            comment = await _commentRepository.AddAsync(comment);
            return comment.Id;
        }
    }
}
