using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Users.Commands.CreateUser
{
    public class CreateCustomerValidation : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerValidation()
        {
            RuleFor(u => u.Email)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .EmailAddress();

            RuleFor(u => u.NickName)
                .MinimumLength(5)
                .NotEmpty()
                .WithMessage("{PropertyName} is required");

            RuleFor(u => u.Password)
                .NotEmpty()
                .WithMessage("Password is required");

            RuleFor(u => u.Address)
                .NotEmpty()
                .WithMessage("{PropertyName} is required");

        }
    }
}
