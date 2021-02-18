using Bookstore.Application.Books;
using Bookstore.Application.Configuration.Data;
using Bookstore.Application.Configuration.Queries;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bookstore.Application.Orders.GetOrderById
{
    public class GetOrderQueryHandler : IQueryHandler<GetOrderQuery, OrderDetailsDTO>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        public GetOrderQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<OrderDetailsDTO> Handle(GetOrderQuery query, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();
            const string sql = "SELECT * FROM Orders o WHERE o.Id = @Id";
            var order = await connection.QuerySingleAsync<OrderDetailsDTO>(sql, new { query.Id });
            const string bookSql = "SELECT b.Id, b.Title, b.Author, b.PagesCount, g.Name as Genre FROM OrderBooks ob INNER JOIN Books b ON b.Id = ob.BookId INNER JOIN Genres g ON g.Id = b.GenreId WHERE ob.OrderId = @Id";
            var books = await connection.QueryAsync<BookDTO>(bookSql, new { order.Id });
            order.Books = books.AsList();

            return order;
        }
    }
}
