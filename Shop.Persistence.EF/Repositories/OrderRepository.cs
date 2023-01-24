using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Contracts.Persistence;
using Shop.Application.Functions.Baskets.Command.DeleteProductsFromCart;
using Shop.Application.Functions.Baskets.Query.GetDetailBasket;
using Shop.Application.Functions.Baskets.Query.GetShoppingCart;
using Shop.Application.UsersContext;
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
        private readonly IUserContext _userContext;

        public OrderRepository(ShopDbContext dbContext, IEmail email, IUserContext userContext) : base(dbContext)
        {
            _dbContext = dbContext;
            _email = email;
            _userContext = userContext;
        }

        public async Task<OrderToSend> CreateOrder(OrderToSend order, int id)
        {
            var shoppingCart = await _dbContext.ShoppingCarts
                .Include(x => x.Products).FirstOrDefaultAsync(x => x.Id == id);

            order.Products = shoppingCart.Products;
            var productCarts = await _dbContext.ProductCart.Where(x => x.ShoppingCartId == shoppingCart.Id).ToListAsync();
            order.Price = order.Products.Sum(x => {
                foreach (var productCart in productCarts)
                {
                        if (x.Id == productCart.ProductId)
                        {
                            return x.Price * productCart.Quantity;
                        }
                 }
                return x.Price;
            });
            var nickName = _userContext.GetUserName;
            var email = _userContext.GetUserEmail;
            var message = new MessageParams(email, "Zamówienie", nickName, await FileReader.ReadOrderFile(nickName, order.Products, order.Price));
            await _email.SendEmail(message);
            await _dbContext.Orders.AddAsync(order);
            shoppingCart.Products.Clear();
            await _dbContext.SaveChangesAsync();
            return order;
        }
    }
}
