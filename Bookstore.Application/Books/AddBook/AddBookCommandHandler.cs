using AutoMapper;
using Bookstore.Application.Books.GetAllBooks;
using Bookstore.Application.Configuration.Commands;
using Bookstore.Domain.Models;
using Bookstore.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bookstore.Application.Books.AddBook
{
    public class AddBookCommandHandler : ICommandHandler<AddBookCommand, BookDTO>
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        public AddBookCommandHandler(IMapper mapper, IBookRepository bookRepository)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
        }
        public async Task<BookDTO> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            var book = _mapper.Map<Book>(request);
            await _bookRepository.AddAsync(book);
            var dto = _mapper.Map<BookDTO>(book);
            return dto;
            
        }
    }
}
