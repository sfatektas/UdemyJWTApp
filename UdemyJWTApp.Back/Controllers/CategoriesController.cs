using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyJWTApp.Back.Core.Application.Dto;
using UdemyJWTApp.Back.Core.Application.Extensions;
using UdemyJWTApp.Back.Core.Application.Features.CQRS.Commands;
using UdemyJWTApp.Back.Core.Application.Features.CQRS.Queries;

namespace UdemyJWTApp.Back.Controllers
{
    [EnableCors("JwtTokenPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IValidator<CategoryCreateDto> _createValidator;
        private readonly IValidator<CategoryUpdateDto> _updateValidator;

        public CategoriesController(IMediator mediator, IMapper mapper, IValidator<CategoryCreateDto> createValidator, IValidator<CategoryUpdateDto> updateValidator)
        {
            _mediator = mediator;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _mediator.Send(new GetAllCategoriesQuery());
            return Ok(data.Where(x=>x.Description!=null));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _mediator.Send(new GetCategoryQuery( id));
            return Ok(data);
        }
        [Authorize(Roles ="Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateDto dto)
        {
            var result = await _createValidator.ValidateAsync(dto);
            if (result.IsValid)
            {
                await _mediator.Send(_mapper.Map<CreateCategoryCommandRequest>(dto));
                return Created("", dto.Description);
            }
            return BadRequest(result.GetErrorMessages());
        }
        [Authorize(Roles = "Admin")]

        [HttpPut]
        public async Task<IActionResult> Update(CategoryUpdateDto dto)
        {
            var result = await _updateValidator.ValidateAsync(dto);
            if (result.IsValid)
            {
                await _mediator.Send(_mapper.Map<UpdateCategoryCommandRequest>(dto));
                return NoContent();
            }
            return BadRequest(result.GetErrorMessages());
        }
        [HttpGet("{id}/Products")]
        public async Task<IActionResult> CategoriesWithProducts(int id)
        {
            var data = await _mediator.Send(new GetCategoriesWithProductsQuery(id));
            return Ok(data);
        }
        [Authorize(Roles ="Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await _mediator.Send(new DeleteCategoryCommandRequest(id));
            return NoContent();
        }
    }
}
