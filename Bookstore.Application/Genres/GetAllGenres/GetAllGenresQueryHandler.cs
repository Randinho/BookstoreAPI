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

namespace Bookstore.Application.Genres.GetAllGenres
{
    public class GetAllGenresQueryHandler : IQueryHandler<GetAllGenresQuery, IEnumerable<GenreDTO>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        public GetAllGenresQueryHandler(IGenreRepository genreRepository, IMapper mapper,
            ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<IEnumerable<GenreDTO>> Handle(GetAllGenresQuery query, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();
            var sql = "SELECT * FROM Genres";

            var genres = await connection.QueryAsync<GenreDTO>(sql);
            return genres;
        }
            
    }
}
