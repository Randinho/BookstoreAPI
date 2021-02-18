using Bookstore.Application.Configuration.Commands;
using Bookstore.Domain.Models;
using Bookstore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bookstore.Application.Orders.PlaceOrder
{
    public class PlaceOrderCommandHandler : ICommandHandler<PlaceOrderCommand, OrderDTO>
    {
        private readonly IOrderRepository _orderRepository;
        public PlaceOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderDTO> Handle(PlaceOrderCommand command, CancellationToken cancellationToken)
        {
            
            var order = await _orderRepository.PlaceOrder(command.CustomerId, command.BooksId);

            return new OrderDTO(order);
        }
    }
}
