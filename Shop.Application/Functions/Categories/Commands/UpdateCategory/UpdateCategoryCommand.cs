using MediatR;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest
    {
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
