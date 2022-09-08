﻿using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Users.Queries.GetUserDetail
{
    public class CustomerViewModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ShoppingCart Basket { get; set; }
        public Address Address { get; set; }
        public string Email { get; set; }
    }
}
