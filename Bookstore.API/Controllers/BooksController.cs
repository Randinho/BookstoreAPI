using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Application.Books.GetAllBooks;
using Bookstore.Application.Books.AddBook;
using Bookstore.Application.Books.EditBook;
using Bookstore.Application.Books.GetBook;
using Bookstore.Application.Books.GetBooksByGenre;

namespace Bookstore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var response = await _mediator.Send(new GetAllBooksQuery());
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var response = await _mediator.Send(new GetBookQuery(id));
            return Ok(response);
        }

        [HttpGet]
        [Route("/api/[controller]/genre/{genreId}")]
        public async Task<IActionResult> GetBooksByGenre(int genreId)
        {
            var response = await _mediator.Send(new GetBooksByGenreQuery(genreId));
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] AddBookCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> EditBook([FromBody] EditBookCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
