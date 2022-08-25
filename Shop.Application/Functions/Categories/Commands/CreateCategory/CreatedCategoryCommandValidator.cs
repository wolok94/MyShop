using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Categories.Commands.CreateCategory
{
    public class CreatedCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreatedCategoryCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} is required");
        }


    }
}
