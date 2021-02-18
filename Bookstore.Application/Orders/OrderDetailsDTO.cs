using Bookstore.Application.Books;
using Bookstore.Application.Books.GetAllBooks;
using Bookstore.Application.Customers;
using Bookstore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Application.Orders
{
    public class OrderDetailsDTO
    {
        public int Id { get; set; }
        public IEnumerable<BookDTO> Books { get; set; }
        public OrderStatus Status { get; set; }
        //public CustomerDTO Customer { get; set; }
    }
}
