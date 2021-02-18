using Bookstore.Application.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Application.Orders.GetOrderById
{
    public class GetOrderQuery : IQuery<OrderDetailsDTO>
    {
        public int Id { get; set; }

        public GetOrderQuery(int id)
        {
            Id = id;
        }
    }
}
