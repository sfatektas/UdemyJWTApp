using MediatR;
using Microsoft.AspNetCore.Mvc;
using UdemyJWTApp.Back.Core.Application.Features.CQRS.Queries;
using UdemyJWTApp.Back.Core.Application.Dto;
using UdemyJWTApp.Back.Core.Application.Features.CQRS.Commands;
using AutoMapper;

namespace UdemyJWTApp.Back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IActionResult> GetAll()
        {
            var data = await _mediator.Send(new GetAllProductsQuery());
            return data == null ? NotFound() : Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _mediator.Send(new GetProductQuery(id));
            if(data.Description == null)
                return NotFound();
            return Ok(data);
        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> RemoveById(int id)
        {
            await _mediator.Send(new DeleteProudctCommandRequest(id));
            return NoContent();
        }

        [HttpPost]

        public async Task<IActionResult> Create(ProductCreateDto dto)
        {
            await _mediator.Send(_mapper.Map<CreateProductCommandRequest>(dto));
            return Created("", dto.Description);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto dto)
        {
            await _mediator.Send(_mapper.Map<UpdateProductCommandRequest>(dto));
            return Ok();
        }
    }
}
