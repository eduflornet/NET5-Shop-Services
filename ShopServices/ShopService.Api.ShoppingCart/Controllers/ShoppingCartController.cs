using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopService.Api.ShoppingCart.Application;

namespace ShopService.Api.ShoppingCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShoppingCartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(Insert.Execute data)
        {
            return await _mediator.Send(data);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CartDto>> GetCart(int id)
        {
            return await _mediator.Send(new Query.Execute {CartSessionId = id});
        }
    }
}
