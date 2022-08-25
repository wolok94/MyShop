﻿using Shop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class OrderToSend
    {
        public int Id { get; set; }
        public Basket Basket { get; set; }
        public int BasketId { get; set; }
        public Customer User { get; set; }
        public int UserId { get; set; }
        public Shipment Shipment { get; set; }
        public DateTime dateOfOrder { get; set; }
        public bool isDelivered { get; set; }

    }
}