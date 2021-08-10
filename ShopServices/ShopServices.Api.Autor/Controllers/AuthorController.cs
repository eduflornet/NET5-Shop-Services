using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopServices.Api.Author.Application;
using ShopServices.Api.Author.Model;

namespace ShopServices.Api.Author.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(Insert.Run data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<AuthorBook>>> GetAuthors()
        {
            return await _mediator.Send(new Query.AuthorList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorBook>> GetAuthorBook(string id)
        {
            return await _mediator.Send(new QueryFilter.UniqueAuthor{AuthorBookGuid = id});
        }


    }
}