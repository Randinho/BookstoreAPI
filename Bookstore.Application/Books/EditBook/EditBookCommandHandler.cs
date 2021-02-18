
using AutoMapper;
using Bookstore.Application.Configuration.Commands;
using Bookstore.Domain.Models;
using Bookstore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bookstore.Application.Books.EditBook
{
    public class EditBookCommandHandler : ICommandHandler<EditBookCommand, BookDTO>
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        public EditBookCommandHandler(IMapper mapper, IBookRepository bookRepository)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
        }
        public async Task<BookDTO> Handle(EditBookCommand command, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.Edit(new Book
            {
                Id = command.Id,
                Author = command.Author,
                Title = command.Title,
                PagesCount = command.PagesCount,
                GenreId = command.GenreId
            });

            var mapped = _mapper.Map<BookDTO>(book);
            return mapped;
        }
    }
}
