﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class Customer : User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Basket Basket { get; set; }
        public OrderToSend Order { get; set; }

    }
}
