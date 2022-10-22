using AutoMapper;
using MediatR;
using UdemyJWTApp.Back.Core.Application.Dto;
using UdemyJWTApp.Back.Core.Application.Features.CQRS.Queries;
using UdemyJWTApp.Back.Core.Application.Interfaces;
using UdemyJWTApp.Back.Core.Domain;

namespace UdemyJWTApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class GetProductHandler : IRequestHandler<GetProductQuery, ProductListDto>
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;

        public GetProductHandler(IMapper mapper, IUow uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<ProductListDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<ProductListDto> (await _uow.GetRepository<Product>().GetByIdAsync(request.Id));
        }
    }
}
