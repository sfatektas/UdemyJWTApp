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
        private readonly IMapper _mapper;
        private readonly IUow _uow;

        public GetAllCategoriesRequestHandler( IMapper mapper, IUow uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<List<CategoryListDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<CategoryListDto>>( await _uow.GetRepository<Category>().GetAllAsync());
        }
    }
}
