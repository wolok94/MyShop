using FluentValidation;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Comments.Command.CreateComment
{
    public class CreateCommentValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentValidator()
        {
            RuleFor(c => c.Description)
                 .NotEmpty()
                 .WithMessage("{PropertyName} is required");
        }
    }
}
