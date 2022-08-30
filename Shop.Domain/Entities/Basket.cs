﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class Basket
    {
        public int Id { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();

    }
}
