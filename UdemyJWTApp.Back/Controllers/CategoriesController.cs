using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyJWTApp.Back.Core.Application.Dto;
using UdemyJWTApp.Back.Core.Application.Features.CQRS.Commands;
using UdemyJWTApp.Back.Core.Application.Features.CQRS.Queries;

namespace UdemyJWTApp.Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CategoriesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
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
            await _mediator.Send(_mapper.Map<CreateCategoryCommandRequest>(dto));
            return Created("",dto.Description);
        }
        [HttpPut]
        public async Task<IActionResult> Update(CategoryUpdateDto dto)
        {
            await _mediator.Send(_mapper.Map<UpdateCategoryCommandRequest>(dto));
            return NoContent();
        }

    }
}
