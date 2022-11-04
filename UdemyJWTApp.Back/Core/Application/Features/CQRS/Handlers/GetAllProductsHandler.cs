using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using UdemyJWTApp.Back.Core.Application.Dto;
using UdemyJWTApp.Back.Core.Application.Features.CQRS.Queries;
using UdemyJWTApp.Back.Core.Application.Interfaces;
using UdemyJWTApp.Back.Core.Domain;
using UdemyJWTApp.Back.Persistance.Context;

namespace UdemyJWTApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, List<ProductListDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;
        private readonly UdemyJWTDbContext _context;

        public GetAllProductsHandler(IMapper mapper, IUow uow, UdemyJWTDbContext context)
        {
            _mapper = mapper;
            _uow = uow;
            _context = context;
        }

        public async Task<List<ProductListDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            //var data = await _uow.GetRepository<Product>().GetAllAsync();
            var data2 = await _context.Products.Include(x => x.Category).ToListAsync();
            var data = await _uow.GetRepository<Product>().GetQueryable().Include(x=>x.Category).ToListAsync();
            return _mapper.Map<List<ProductListDto>>(data); 
        }
    }
}
