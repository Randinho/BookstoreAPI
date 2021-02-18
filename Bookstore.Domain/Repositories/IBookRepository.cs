using Bookstore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Domain.Repositories
{
    public interface IBookRepository
    {
        Task AddAsync(Book book);
        Task<Book> Edit(Book book);
    }
}
