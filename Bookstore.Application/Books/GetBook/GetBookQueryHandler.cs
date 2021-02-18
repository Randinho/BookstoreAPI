using AutoMapper;
using Bookstore.Application.Configuration.Data;
using Bookstore.Application.Configuration.Queries;
using Bookstore.Domain.Repositories;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bookstore.Application.Books.GetBook
{
    public class GetBookQueryHandler : IQueryHandler<GetBookQuery, BookDTO>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetBookQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<BookDTO> Handle(GetBookQuery query, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();
            const string sql = "SELECT B.Id, B.Title, B.Author, B.PagesCount, G.Name as Genre FROM Books B INNER JOIN Genres G ON B.GenreId = G.Id WHERE B.Id = @Id";
            var book = await connection.QuerySingleAsync<BookDTO>(sql, new { query.Id });

            return book;
        }
    }
}
