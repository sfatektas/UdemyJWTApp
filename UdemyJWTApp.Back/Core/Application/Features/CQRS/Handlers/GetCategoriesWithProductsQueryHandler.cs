using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UdemyJWTApp.Back.Core.Application.Dto;
using UdemyJWTApp.Back.Core.Application.Features.CQRS.Queries;
using UdemyJWTApp.Back.Core.Domain;
using UdemyJWTApp.Back.Persistance.Context;

namespace UdemyJWTApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class GetCategoriesWithProductsQueryHandler : IRequestHandler<GetCategoriesWithProductsQuery, List<ProductListDto>>
    {
        private readonly UdemyJWTDbContext _context;
        private readonly IMapper _mapper;

        public GetCategoriesWithProductsQueryHandler(UdemyJWTDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ProductListDto>> Handle(GetCategoriesWithProductsQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.Categories.Include(x => x.Products).SingleOrDefaultAsync(x => x.Id == request.Id);
            return _mapper.Map<List<ProductListDto>>(data.Products);
        }
    }
}
