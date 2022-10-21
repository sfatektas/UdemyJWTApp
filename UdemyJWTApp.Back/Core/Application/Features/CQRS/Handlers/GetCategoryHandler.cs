using AutoMapper;
using MediatR;
using UdemyJWTApp.Back.Core.Application.Dto;
using UdemyJWTApp.Back.Core.Application.Features.CQRS.Queries;
using UdemyJWTApp.Back.Core.Application.Interfaces;
using UdemyJWTApp.Back.Core.Domain;

namespace UdemyJWTApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class GetCategoryHandler : IRequestHandler<GetCategoryQuery, CategoryListDto>
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public GetCategoryHandler(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CategoryListDto> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<CategoryListDto>(await _repository.GetByIdAsync(request.Id));
        }
    }
}
