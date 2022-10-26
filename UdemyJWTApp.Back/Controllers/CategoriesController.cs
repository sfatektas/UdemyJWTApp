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
        [Authorize(Roles ="Member")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var request = Request;
            var data = await _mediator.Send(new GetAllCategoriesQuery());
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _mediator.Send(new GetCategoryQuery( id));
            return Ok(data);
        }
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

    }
}
