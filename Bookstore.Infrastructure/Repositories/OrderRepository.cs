using Bookstore.Domain.Models;
using Bookstore.Domain.Repositories;
using Bookstore.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationContext _context;
        public OrderRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task ChangeStatus(int orderId, OrderStatus status)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order != null  && status != OrderStatus.Placed) 
            {
                order.Status = status;
                _context.Update(order);
                await _context.SaveChangesAsync();
            }
            
        }

        public async Task<Order> PlaceOrder(int customerId, IEnumerable<int> BooksId)
        {
            var order = new Order
            {
                Status = OrderStatus.Placed,
                CustomerId = customerId
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            await SetOrderBooks(BooksId, order.Id);

            return order;
        }

        private async Task SetOrderBooks(IEnumerable<int> BooksId, int orderId)
        {
            foreach(var item in BooksId)
            {
                var orderBook = new OrderBook
                {
                    BookId = item,
                    OrderId = orderId
                };
                  await _context.OrderBooks.AddAsync(orderBook);                
            }
             await _context.SaveChangesAsync();
        }
    }
}
