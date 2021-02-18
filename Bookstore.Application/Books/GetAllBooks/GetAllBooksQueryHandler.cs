using AutoMapper;
using Bookstore.Application.Configuration.Data;
using Bookstore.Application.Configuration.Queries;
using Dapper;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bookstore.Application.Books.GetAllBooks
{
    public class GetAllBooksQueryHandler : IQueryHandler<GetAllBooksQuery, IEnumerable<BookDTO>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetAllBooksQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<IEnumerable<BookDTO>> Handle(GetAllBooksQuery query, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();
            const string sql = "SELECT B.Id, B.Title, B.Author, B.PagesCount, G.Name as Genre FROM Books B INNER JOIN Genres G on B.GenreId = G.Id";

            var books = await connection.QueryAsync<BookDTO>(sql);
            return books.AsList(); 
                
        }

        
    }
}
