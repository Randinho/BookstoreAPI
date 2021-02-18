using System;
using System.Collections.Generic;
using System.Text;

namespace Bookstore.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }
        public virtual ICollection<OrderBook> OrderBooks { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

    }
}
