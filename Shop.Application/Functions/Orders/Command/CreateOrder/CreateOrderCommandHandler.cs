using AutoMapper;
using MediatR;
using Shop.Application.Contracts.Persistence;
using Shop.Application.Functions.Categories.Commands.CreateCategory;
using Shop.Application.Functions.Exceptions;
using Shop.Application.Functions.Orders.Command.CreateOrder;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Shop.Application.Functions.Orders.Command.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly IUserContext _userContext;

        public CreateOrderCommandHandler(IMapper mapper, IOrderRepository orderRepository, IUserContext userContext)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _userContext = userContext;
        }
        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateOrderValidator();
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid)
            {
                throw new ValidationShopException(validatorResult);
            }
            request.BasketId = (int)_userContext.GetShoppingCartId;
            request.UserId = (int)_userContext.GetUserId;
            var order = _mapper.Map<OrderToSend>(request);
            order = await _orderRepository.CreateOrder(order);
            return order.Id;
        }
    }
}
