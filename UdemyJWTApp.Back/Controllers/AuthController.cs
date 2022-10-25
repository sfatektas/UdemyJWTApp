using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using UdemyJWTApp.Back.Core.Application.Features.CQRS.Commands;
using UdemyJWTApp.Back.Core.Application.Features.CQRS.Queries;
using UdemyJWTApp.Back.Infrastructure.Tools;

namespace UdemyJWTApp.Back.Controllers
{
    [EnableCors("JwtTokenPolicy")]
    [Route("api/[controller]")]
    [ApiController]


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

        [HttpPost("[action]")]
        public async Task<IActionResult> SignIn(CheckUserQueryRequest request)
        {
            var response = await _mediator.Send(request);
            if (response.IsExist)
            {
                var token = JwtTokenGenerator.GenerateToken(response);
                return Created("",token);
            }
            return BadRequest("Kullanıcı Adı veya şifre yanlış.");
        }
    }
}
