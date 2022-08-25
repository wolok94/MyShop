using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Orders.Command.CreateOrder
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderValidator()
        {
            RuleFor(o => o.BasketId)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .GreaterThan(0);

            RuleFor(o => o.UserId)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .GreaterThan(0);

            RuleFor(o => o.Shipment)
                .NotEmpty()
                .WithMessage("{PropertyName} is required");

        }
    }
}
