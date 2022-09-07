using MediatR;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int InStock { get; set; }
        public int CategoryId { get; set; }
        public string? ImageUrl { get; set; }
    }
}
