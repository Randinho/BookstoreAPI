using System;
using System.Collections.Generic;
using System.Text;

namespace Bookstore.Domain.Models
{
    public class OrderBook
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
