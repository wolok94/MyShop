using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.DtoModels
{
    public class UserProductDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public List<UserCommentDto> Comments { get; set; }
        public string ImageUrl { get; set; }
    }
}
