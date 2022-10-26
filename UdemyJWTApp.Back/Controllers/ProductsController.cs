using MediatR;
using Microsoft.AspNetCore.Mvc;
using UdemyJWTApp.Back.Core.Application.Features.CQRS.Queries;
using UdemyJWTApp.Back.Core.Application.Dto;
using UdemyJWTApp.Back.Core.Application.Features.CQRS.Commands;
using AutoMapper;
using FluentValidation;
using UdemyJWTApp.Back.Core.Application.Extensions;

namespace UdemyJWTApp.Back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IValidator<ProductCreateDto> _CreateValidator;
        private readonly IValidator<ProductUpdateDto> _Updatevalidator;

        public ProductsController(IMediator mediator, IMapper mapper, IValidator<ProductCreateDto> createValidator, IValidator<ProductUpdateDto> updatevalidator)
        {
            _mediator = mediator;
            _mapper = mapper;
            _CreateValidator = createValidator;
            _Updatevalidator = updatevalidator;
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
            var result = await _CreateValidator.ValidateAsync(dto);
            if (result.IsValid)
            {
                await _mediator.Send(_mapper.Map<CreateProductCommandRequest>(dto));
                return Created("", dto.Description);
            }
            return BadRequest(result.GetErrorMessages());
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto dto)
        {
            var result = await _Updatevalidator.ValidateAsync(dto);
            if (result.IsValid)
            {
                await _mediator.Send(_mapper.Map<UpdateProductCommandRequest>(dto));
                return NoContent();
            }
            return BadRequest(result.GetErrorMessages());

        }
    }
}
