using Microsoft.EntityFrameworkCore;
using Shop.Application.Contracts.Persistence;
using Shop.Domain.Entities;
using Shop.Persistence.EF.SendingEmail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.EF.Repositories
{
    public class OrderRepository : BaseRepository<OrderToSend>, IOrderRepository
    {
        private readonly ShopDbContext _dbContext;
        private readonly IEmail _email;
 

        public OrderRepository(ShopDbContext dbContext, IEmail email) : base(dbContext)
        {
            _dbContext = dbContext;
            _email = email;
        }

        public async Task<OrderToSend> CreateOrder(OrderToSend order)
        {
            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();
            var orderToSend = await _dbContext.Orders
                .Include(x => x.User)
                .Include(x => x.Basket)
                .ThenInclude(x => x.Products)
                .FirstOrDefaultAsync(x => x.Id == order.Id);
            orderToSend.Price = orderToSend.Basket.Products.Sum(x => x.Price);
            await _dbContext.SaveChangesAsync();
            var nickName = orderToSend.User.NickName;
            var message = new MessageParams(order.User.Email, "Zamówienie", orderToSend.User.NickName, await FileReader.ReadOrderFile(nickName, orderToSend.Basket.Products, orderToSend.Price));
            await _email.SendEmail(message);
            return order;
        }
    }
}
