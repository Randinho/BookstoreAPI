using Bookstore.Application.Configuration.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Application.Books.EditBook
{
    public class EditBookCommand : ICommand<BookDTO>
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public int PagesCount { get; set; }
        public int GenreId { get; set; }
    }
}
