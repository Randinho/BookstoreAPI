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
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationContext _context;
        public GenreRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Genre>> ListAsync()
        {
            var genres = await _context.Genres.ToListAsync();
            return genres;
        }
    }
}
