using AutoMapper;
using MediatR;
using Shop.Application.Contracts.Persistence;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Users.Queries.GetUserDetail
{
    public class GetUserDetailQueryHandler : IRequestHandler<GetUserDetailQuery, UserViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<User> _userRepository;
        public GetUserDetailQueryHandler(IMapper mapper, IAsyncRepository<User> userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        async Task<UserViewModel> IRequestHandler<GetUserDetailQuery, UserViewModel>.Handle(GetUserDetailQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            var mappedUser = _mapper.Map<UserViewModel>(user);
            return mappedUser;
        }
    }
}
