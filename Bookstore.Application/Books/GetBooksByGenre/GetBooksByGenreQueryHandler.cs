using Bookstore.Application.Configuration.Data;
using Bookstore.Application.Configuration.Queries;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bookstore.Application.Books.GetBooksByGenre
{
    public class GetBooksByGenreQueryHandler : IQueryHandler<GetBooksByGenreQuery, IEnumerable<BookDTO>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetBooksByGenreQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<IEnumerable<BookDTO>> Handle(GetBooksByGenreQuery query, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();
            var sql = "SELECT b.Id, b.Title, b.Author, b.PagesCount, g.Name as Genre FROM Books b INNER JOIN Genres g on g.Id = b.GenreId WHERE g.Id = @GenreId";
            var books = await connection.QueryAsync<BookDTO>(sql, new { query.GenreId });

            return books.AsList();
        }

    }
}
