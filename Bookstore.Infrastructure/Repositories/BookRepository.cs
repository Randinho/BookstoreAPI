using Bookstore.Domain.Models;
using Bookstore.Domain.Repositories;
using Bookstore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationContext _context;
        public BookRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Book> GetBookById(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
                return book;
            return null;
        }

        public async Task AddAsync(Book book)
        {
            await _context.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task<Book> Edit(Book book)
        {
            var existingBook = await _context.Books.FindAsync(book.Id);
            if(existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.PagesCount = book.PagesCount;
                existingBook.GenreId = book.GenreId;       
            }

            _context.Books.Update(existingBook);
            await _context.SaveChangesAsync();
            return existingBook;
        }
    }
}
