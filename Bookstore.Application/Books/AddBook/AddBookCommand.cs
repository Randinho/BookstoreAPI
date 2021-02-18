using Bookstore.Application.Books.GetAllBooks;
using Bookstore.Application.Configuration.Commands;
using Bookstore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bookstore.Application.Books.AddBook
{
    public class AddBookCommand : ICommand<BookDTO>
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public int PagesCount { get; set; }
        public int GenreId { get; set; }
    }
}
