using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Exceptions
{
    public class ValidationShopException : Exception
    {
        public List<string> ErrorMessages { get; set; }

        public ValidationShopException(ValidationResult validationResult)
        {
            ErrorMessages = new List<String>();

            foreach(var item in validationResult.Errors)
            {
                ErrorMessages.Add(item.ErrorMessage);
            }
        }
    }
}
