using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Contracts.Persistence;
using Shop.Application.Functions.Baskets.Command.DeleteProductsFromCart;
using Shop.Application.Functions.Baskets.Query.GetDetailBasket;
using Shop.Application.Functions.Baskets.Query.GetShoppingCart;
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
        private readonly IMediator _mediator;


        public OrderRepository(ShopDbContext dbContext, IEmail email, IMediator mediator) : base(dbContext)
        {
            _dbContext = dbContext;
            _email = email;
            _mediator = mediator;
        }

        public async Task<OrderToSend> CreateOrder(OrderToSend order, int id)
        {
            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();
            var shoppingCart = await _mediator.Send(new GetShoppingCartQuery());
            var orderToSend = await _dbContext.Orders
                .Include(x => x.User)
                .Include(x => x.Products)
                .FirstOrDefaultAsync(x => x.Id == order.Id);
            orderToSend.Products = shoppingCart.Products;
            orderToSend.Price = orderToSend.Products.Sum(x => x.Price);
            await _dbContext.SaveChangesAsync();
            var nickName = orderToSend.User.NickName;
            var message = new MessageParams(order.User.Email, "Zamówienie", orderToSend.User.NickName, await FileReader.ReadOrderFile(nickName, orderToSend.Products, orderToSend.Price));
            await _email.SendEmail(message);
            await _mediator.Send(new DeleteProductsFromCartCommand() { ShoppingCartId = id });
            return order;
        }
    }
}
