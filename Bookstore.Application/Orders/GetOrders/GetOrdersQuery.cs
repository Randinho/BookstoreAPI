using Bookstore.Application.Configuration;
using Bookstore.Application.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Application.Orders.GetOrders
{
    public class GetOrdersQuery : IQuery<CustomerDTO>
    {
        public int CustomerId { get; set; }
        public GetOrdersQuery(int customerId)
        {
            CustomerId = customerId;
        }
    }
}
