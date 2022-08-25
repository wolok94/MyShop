using AutoMapper;
using MediatR;
using Shop.Application.Contracts.Persistence;
using Shop.Application.Functions.Comments.Command.UpdateComment;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Orders.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Order> _commentRepository;
        public UpdateOrderCommandHandler(IMapper mapper, IAsyncRepository<Order> commentRepository)
        {
            _mapper = mapper;
            _commentRepository = commentRepository;
        }
        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var comment = _mapper.Map<Comment>(request);
            await _commentRepository.UpdateAsync(comment);
            return Unit.Value;
        }
    }
}
