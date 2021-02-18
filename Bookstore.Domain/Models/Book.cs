using System;
using System.Collections.Generic;
using System.Text;

namespace Bookstore.Domain.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PagesCount { get; set; }
        public virtual Genre Genre { get; set; }
        public int GenreId { get; set; }
        public virtual ICollection<OrderBook> OrderBooks { get; set; }
    }
}
