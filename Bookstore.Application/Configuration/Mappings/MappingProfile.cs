using AutoMapper;
using Bookstore.Application.Books;
using Bookstore.Application.Books.AddBook;
using Bookstore.Application.Books.GetAllBooks;
using Bookstore.Application.Genres.GetAllGenres;
using Bookstore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Application.Configuration.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDTO>().ForMember(dest => dest.Genre, opt => opt.MapFrom(x => x.Genre.Name));
            CreateMap<Genre, GenreDTO>();
            CreateMap<AddBookCommand, Book>();
        }
    }
}
