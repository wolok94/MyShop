using AutoMapper;
using MediatR;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Shop.Application.Contracts.Persistence;
using Shop.Application.Functions.Categories.Commands.CreateCategory;
using Shop.Application.Functions.Exceptions;
using Shop.Application.Functions.Orders.Command.CreateOrder;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Users.Commands.CreateUser
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly IPasswordHasher<Customer> _passwordHasher;

        public CreateCustomerCommandHandler(IMapper mapper, ICustomerRepository customerRepository, IPasswordHasher<Customer> passwordHasher)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _passwordHasher = passwordHasher;
        }
        public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateCustomerValidation();
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid)
            {
                throw new ValidationShopException(validatorResult);
            }
            var customer = _mapper.Map<Customer>(request);
            customer.hashedPassword = GetHashedPassword(customer, request.Password);
            customer = await _customerRepository.RegisterUser(customer, request.Password);
            return customer.Id;
        }
        public string GetHashedPassword(Customer user, string password)
        {
            var hashedPassword = _passwordHasher.HashPassword(user, password);
            return hashedPassword;
        }
    }
}
