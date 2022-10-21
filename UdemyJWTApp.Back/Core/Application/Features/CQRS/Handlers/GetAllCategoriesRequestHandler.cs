using AutoMapper;
using MediatR;
using UdemyJWTApp.Back.Core.Application.Dto;
using UdemyJWTApp.Back.Core.Application.Features.CQRS.Queries;
using UdemyJWTApp.Back.Core.Application.Interfaces;
using UdemyJWTApp.Back.Core.Domain;

namespace UdemyJWTApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class GetAllCategoriesRequestHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryListDto>>
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public GetAllCategoriesRequestHandler(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<CategoryListDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<CategoryListDto>>( await _repository.GetAllAsync());
        }
    }
}
