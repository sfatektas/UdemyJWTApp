using MediatR;
using UdemyJWTApp.Back.Core.Application.Features.CQRS.Commands;
using UdemyJWTApp.Back.Core.Application.Interfaces;
using UdemyJWTApp.Back.Core.Domain;

namespace UdemyJWTApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class DeleteProductCommandRequestHandler : IRequestHandler<DeleteProudctCommandRequest>
    {
        private readonly IUow _uow;

        public DeleteProductCommandRequestHandler(IUow uow)
        {
            _uow = uow;
        }

        public async Task<Unit> Handle(DeleteProudctCommandRequest request, CancellationToken cancellationToken)
        {
            await _uow.GetRepository<Product>().Remove(request.Id);
            await _uow.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
