using FluentValidation;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Products.Commands.CreateProduct
{
    public class CreatedProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreatedProductCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("{PropertyName} is required");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("{PropertyName} is required");

            RuleFor(x => x.Price)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .GreaterThanOrEqualTo(1);

            RuleFor(x => x.InStock)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.CategoryId)
                .NotEmpty()
                .WithMessage("{PropertyName} is required");

        }
    }
}
