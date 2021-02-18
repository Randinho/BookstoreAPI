using System;
using System.Collections.Generic;
using System.Text;

namespace Bookstore.Domain.Models
{
    public enum OrderStatus
    {
        Placed = 0,
        InRealization = 1,
        Sent = 2,
        Delivered = 3,
        Cancelled = 4
    }
}
