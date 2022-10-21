using AutoMapper;
using MediatR;
using System.Collections.Generic;
using UdemyJWTApp.Back.Core.Application.Dto;
using UdemyJWTApp.Back.Core.Application.Features.CQRS.Queries;
using UdemyJWTApp.Back.Core.Application.Interfaces;
using UdemyJWTApp.Back.Core.Domain;

namespace UdemyJWTApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, List<ProductListDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Product> _repository;

        public GetAllProductsHandler(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ProductListDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<ProductListDto>>(await _repository.GetAllAsync()); 
        }
    }
}
