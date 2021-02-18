using Bookstore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Infrastructure.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderBook> OrderBooks { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<OrderBook>().HasKey(p => new { p.BookId, p.OrderId });

            builder.Entity<Genre>().HasData(
                new Genre
                {
                    Id = 1,
                    Name = "Thriller"
                },
                new Genre 
                { 
                    Id = 2,
                    Name = "Fantasy"
                });

            builder.Entity<Book>().HasData(new Book
            {
                Id = 1,
                Author = "Jones",
                Title = "Sample",
                PagesCount = 325,
                GenreId = 1
            },
            new Book
            {
                Id = 2,
                Author = "Jane Doe",
                Title = "Dragons",
                PagesCount = 232,
                GenreId = 2
            });
        }
    }
}
