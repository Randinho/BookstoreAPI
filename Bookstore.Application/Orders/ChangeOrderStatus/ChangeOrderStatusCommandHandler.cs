using Bookstore.Application.Configuration.Commands;
using Bookstore.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Bookstore.Domain.Models;

namespace Bookstore.Application.Orders.ChangeOrderStatus
{
    public class ChangeOrderStatusCommandHandler : ICommandHandler<ChangeOrderStatusCommand>
    {
        private readonly IOrderRepository _orderRepository;
        public ChangeOrderStatusCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Unit> Handle(ChangeOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var status = request.Status switch
            {
                1 => OrderStatus.InRealization,
                2 => OrderStatus.Sent,
                3 => OrderStatus.Delivered,
                4 => OrderStatus.Cancelled,
                _ => OrderStatus.Placed
            };
            await _orderRepository.ChangeStatus(request.Id, status);
            return Unit.Value;


        }
    }
}
