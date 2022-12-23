using AutoMapper;
using MediatR;
using Shop.Application.Contracts.Persistence;
using Shop.Application.Functions.Users.Queries.Login;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Users.Queries.GetUserDetail
{
    public class GetCustomerDetailQueryHandler : IRequestHandler<GetCustomerDetailQuery, LogedUserDto>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        public GetCustomerDetailQueryHandler(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }
        async Task<LogedUserDto> IRequestHandler<GetCustomerDetailQuery, LogedUserDto>.Handle(GetCustomerDetailQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetUserByNickName(request.Nickname);
            return customer;
        }
    }
}
