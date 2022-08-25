using AutoMapper;
using MediatR;
using Shop.Application.Contracts.Persistence;
using Shop.Application.Functions.Orders.Command.CreateOrder;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<User> _orderRepository;
        public CreateUserCommandHandler(IMapper mapper, IAsyncRepository<User> orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }
        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User(request);
            user = await _orderRepository.AddAsync(user);
            return user.Id;
        }
    }
}
