﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Users.Queries.GetUserDetail
{
    public class GetCustomerDetailQuery : IRequest<CustomerViewModel>
    {
        public int Id { get; set; }
    }
}