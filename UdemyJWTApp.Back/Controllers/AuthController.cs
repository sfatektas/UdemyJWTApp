using MediatR;
using Microsoft.AspNetCore.Mvc;
using UdemyJWTApp.Back.Core.Application.Features.CQRS.Commands;

namespace UdemyJWTApp.Back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(UserRegisterCommandRequest cmnd)
        {
            await _mediator.Send(cmnd);
            return Ok();
        }
    }
}
