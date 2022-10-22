using AutoMapper;
using MediatR;
using System.Net.NetworkInformation;
using UdemyJWTApp.Back.Core.Application.Dto;
using UdemyJWTApp.Back.Core.Application.Features.CQRS.Queries;
using UdemyJWTApp.Back.Core.Application.Interfaces;
using UdemyJWTApp.Back.Core.Domain;

namespace UdemyJWTApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class GetCategoryHandler : IRequestHandler<GetCategoryQuery, CategoryListDto>
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;

        public GetCategoryHandler(IMapper mapper, IUow uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<CategoryListDto> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<CategoryListDto>(await _uow.GetRepository<Category>().GetByIdAsync(request.Id));
        }
    }
}
