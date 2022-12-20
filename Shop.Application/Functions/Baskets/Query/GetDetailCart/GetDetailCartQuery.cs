using MediatR;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Baskets.Query.GetDetailBasket
{
    public class GetDetailCartQuery : IRequest<GetDetailCartView>
    {
    }
}
