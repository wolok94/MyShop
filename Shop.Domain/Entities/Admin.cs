﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class Admin : User
    {
        public int Id { get; set; }
        public string ShopName { get; set; }
    }
}
