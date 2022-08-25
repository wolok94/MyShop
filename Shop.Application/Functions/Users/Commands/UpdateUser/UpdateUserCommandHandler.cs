using AutoMapper;
using MediatR;
using Shop.Application.Contracts.Persistence;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<User> _userRepository;
        public UpdateUserCommandHandler(IMapper mapper, IAsyncRepository<User> userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var User = _mapper.Map<User>(request);
            await _userRepository.UpdateAsync(User);
            return Unit.Value;
        }
    }
}
