using Moq;
using Shop.Application.Contracts.Persistence;
using Shop.Application.Functions.Baskets.Query.GetShoppingCart;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Shop.Application.UnitTest.Helper
{
    public static class GetBasketHelper
    {

        public static IMock<IShoppingCartRepository> GetShoppingCart()
        {

            var shoppingCarts = GetShoppingCarts();
            var mockRepository = new Mock<IShoppingCartRepository>();
            mockRepository.Setup(x => x.AddAsync(It.IsAny<ShoppingCart>())).ReturnsAsync((ShoppingCart shoppingCart) =>
            {
                shoppingCarts.Add(shoppingCart);
                return shoppingCart;
            });

            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(shoppingCarts);




            return mockRepository;
        }

        public static List<ShoppingCart> GetShoppingCarts()
        {

            var shoppingCarts = new List<ShoppingCart>
            {
                new ShoppingCart
                {


                }
            };
            return shoppingCarts;
        }
    }
}
