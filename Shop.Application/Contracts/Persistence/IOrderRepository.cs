using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Contracts.Persistence
{
    public interface IOrderRepository : IAsyncRepository<OrderToSend>
    {
        Task<OrderToSend> CreateOrder(OrderToSend order, int shoppingCartId);
    }
}
