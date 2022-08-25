using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}
