using Bookstore.Application.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Application.Books.GetBook
{
    public class GetBookQuery : IQuery<BookDTO>
    {
        public int Id { get; set; }

        public GetBookQuery(int id)
        {
            Id = id;
        }
    }
}
