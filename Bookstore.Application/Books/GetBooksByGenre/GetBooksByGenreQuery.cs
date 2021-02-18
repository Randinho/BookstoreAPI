using Bookstore.Application.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Application.Books.GetBooksByGenre
{
    public class GetBooksByGenreQuery : IQuery<IEnumerable<BookDTO>>
    {
        public int GenreId { get; set; }

        public GetBooksByGenreQuery(int id)
        {
            GenreId = id;
        }
    }
}
