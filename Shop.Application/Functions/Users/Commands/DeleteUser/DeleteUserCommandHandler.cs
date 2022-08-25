using AutoMapper;
using MediatR;
using Shop.Application.Contracts.Persistence;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<User> _userRepository;
        public DeleteUserCommandHandler(IMapper mapper, IAsyncRepository<User> userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var orderToDelete = await _userRepository.GetByIdAsync(request.Id);
            await _userRepository.DeleteAsync(orderToDelete);
            return Unit.Value;
        }
    }
}
