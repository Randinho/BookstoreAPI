using Bookstore.Application.Configuration.Commands;
using Bookstore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bookstore.Application.Orders.PlaceOrder
{
    public class PlaceOrderCommand : ICommand<OrderDTO>
    {
        public List<int> BooksId { get; set; }
        public int CustomerId { get; set; }

        public PlaceOrderCommand(List<int> books, int customerId)
        {
            BooksId = books;
            CustomerId = customerId;
        }
    }
}
