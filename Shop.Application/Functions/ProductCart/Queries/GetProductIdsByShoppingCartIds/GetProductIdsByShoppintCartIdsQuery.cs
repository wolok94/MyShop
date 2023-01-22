﻿using MediatR;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.ProductCarts.Queries.GetProductIdsByShoppingCartIds
{
    public class GetProductIdsByShoppintCartIdsQuery : IRequest<List<ProductCart>>
    {
        public int ShoppingCartId { get; set; }
    }
}