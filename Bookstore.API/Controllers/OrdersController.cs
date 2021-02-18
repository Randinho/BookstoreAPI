using Bookstore.Application.Orders.ChangeOrderStatus;
using Bookstore.Application.Orders.GetOrderById;
using Bookstore.Application.Orders.GetOrders;
using Bookstore.Application.Orders.PlaceOrder;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("{customerId}")]
        public async Task<IActionResult> PlaceOrder([FromBody] List<int> booksId, int customerId)
        {
            var response = await _mediator.Send(new PlaceOrderCommand(booksId, customerId));
            return Ok(response);
        }

        [HttpGet]
        [Route("/api/[controller]/customer/{customerId}")]
        public async Task<IActionResult> GetOrders(int customerId)
        {
            var response = await _mediator.Send(new GetOrdersQuery(customerId));
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var response = await _mediator.Send(new GetOrderQuery(id));
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> ChangeOrderStatus([FromBody] ChangeOrderStatusCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
