﻿using MediatR;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Baskets.Query.GetShoppingCart
{
    public class GetShoppingCartQuery : IRequest<ShoppingCart>
    {
    }
}
