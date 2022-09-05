﻿using MediatR;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Comments.Command.UpdateComment
{
    public class UpdateCommentCommand : IRequest
    {
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
