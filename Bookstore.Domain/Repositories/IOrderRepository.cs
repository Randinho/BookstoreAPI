using Bookstore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> PlaceOrder(int customerId, IEnumerable<int> BooksId);
        Task ChangeStatus(int orderId, OrderStatus status);
    }
}
