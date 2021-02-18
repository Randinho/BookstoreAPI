using Bookstore.Application.Books;
using Bookstore.Application.Books.GetAllBooks;
using Bookstore.Application.Configuration;
using Bookstore.Application.Configuration.Data;
using Bookstore.Application.Configuration.Queries;
using Bookstore.Application.Customers;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bookstore.Application.Orders.GetOrders
{
    public class GetOrdersQueryHandler : IQueryHandler<GetOrdersQuery, CustomerDTO>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        public GetOrdersQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<CustomerDTO> Handle(GetOrdersQuery query, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();
            var customerSql = "SELECT c.Id, c.FirstName, c.LastName, c.Email, c.PhoneNumber FROM Customers c WHERE c.Id = @CustomerId";
            var customer = await connection.QuerySingleAsync<CustomerDTO>(customerSql, new { query.CustomerId });

            var orderSql = "SELECT o.Id, o.Status FROM Orders o WHERE o.CustomerId = @CustomerId";
            var orders = await connection.QueryAsync<OrderDetailsDTO>(orderSql, new { query.CustomerId });
            orders = orders.AsList();

            foreach(var item in orders)
            {
                var booksSql = "SELECT b.Id, b.Title, b.Author, b.PagesCount, g.Name as Genre FROM OrderBooks ob INNER JOIN Books b on b.Id = ob.BookId INNER JOIN Genres g on g.Id = b.GenreId WHERE ob.OrderId = @Id";
                var books = await connection.QueryAsync<BookDTO>(booksSql, new { item.Id });
                item.Books = books.AsList();
            }
            customer.Orders = orders;
            return customer;
            
        }
    }
}
