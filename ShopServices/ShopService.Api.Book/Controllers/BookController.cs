using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopService.Api.Book.Application;

namespace ShopService.Api.Book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(Insert.Run data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<BookDto>>> GetBooks()
        {
            return await _mediator.Send(new Query.BookList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetUniqueBook(Guid id)
        {
            return await _mediator.Send(new QueryFilter.UniqueBook {BookId = id});
        }

    }
}
