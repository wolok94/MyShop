using AutoMapper;
using FluentAssertions;
using Moq;
using Shop.Application.Contracts.Persistence;
using Shop.Application.Functions.Baskets.Command.CreateBasket;
using Shop.Application.Mapper;
using Shop.Application.UnitTest.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.UnitTest.Basket.Commands
{
    public class CreateBasketTest
    {

        private IMock<IShoppingCartRepository> _mockRepository;
        private IMapper _mapper;

        public CreateBasketTest()
        {
            _mockRepository = GetBasketHelper.GetShoppingCart();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]

        public async Task AddAsync_ForValidModel_ReturnsShoppingCart()
        {
            var allShoppingCartsBeforeCount = (await _mockRepository.Object.GetAll()).Count;
            var handler = new CreateCartCommandHandler(_mapper, _mockRepository.Object);
            
            var result = await handler.Handle(new CreateCartCommand(), CancellationToken.None);
            var allShoppingCartsAfterCount = (await _mockRepository.Object.GetAll()).Count;

            allShoppingCartsAfterCount.Should().Be(allShoppingCartsBeforeCount + 1);


            
        }

    }
}
