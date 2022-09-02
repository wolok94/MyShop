using AutoMapper;
using MediatR;
using Shop.Application.Contracts.Persistence;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Users.Queries.Login
{
    public class LoginCustomerQueryHandler : IRequestHandler<LoginCustomerQuery, Customer>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public LoginCustomerQueryHandler(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }
        public Task<Customer> Handle(LoginCustomerQuery request, CancellationToken cancellationToken)
        {
            var customerDto = _mapper.Map<LoginDto>(request);
            var customer = _customerRepository.Login(customerDto);
            return customer;
        }
    }
}
