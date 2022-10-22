using AutoMapper;
using MediatR;
using UdemyJWTApp.Back.Core.Application.Features.CQRS.Commands;
using UdemyJWTApp.Back.Core.Application.Interfaces;
using UdemyJWTApp.Back.Core.Domain;

namespace UdemyJWTApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class CreateProductCommandRequestHandler : IRequestHandler<CreateProductCommandRequest>
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;

        public CreateProductCommandRequestHandler(IMapper mapper, IUow uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _uow.GetRepository<Product>().CreateEntity(_mapper.Map<Product>(request));
            await _uow.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
