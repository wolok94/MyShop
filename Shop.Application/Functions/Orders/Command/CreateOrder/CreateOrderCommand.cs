﻿using MediatR;
using Shop.Domain.Entities;
using Shop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Orders.Command.CreateOrder
{
    public class CreateOrderCommand : IRequest<int>
    {
        public int BasketId { get; set; }
        public int UserId { get; set; }
        public Shipment Shipment { get; set; }

    }
}
