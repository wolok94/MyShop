﻿using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.DtoModels
{
    public class UserCommentDto
    {
        public string UserName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
