using Bookstore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Application.Orders
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }
        public IEnumerable<OrderBook> OrderBooks { get; set; }
        public int CustomerId { get; set; }

        public OrderDTO(Order order)
        {
            Id = order.Id;
            Status = order.Status;
            OrderBooks = order.OrderBooks;
            CustomerId = order.CustomerId;
        }
    }
}
