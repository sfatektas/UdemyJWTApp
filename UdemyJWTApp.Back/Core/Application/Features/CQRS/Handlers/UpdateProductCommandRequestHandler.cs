using AutoMapper;
using MediatR;
using UdemyJWTApp.Back.Core.Application.Features.CQRS.Commands;
using UdemyJWTApp.Back.Core.Application.Interfaces;
using UdemyJWTApp.Back.Core.Domain;

namespace UdemyJWTApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class UpdateProductCommandRequestHandler : IRequestHandler<UpdateProductCommandRequest>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public UpdateProductCommandRequestHandler(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _uow.GetRepository<Product>().UpdateEntity(_mapper.Map<Product>(request));
            await _uow.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
