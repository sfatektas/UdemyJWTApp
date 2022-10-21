using MediatR;
using UdemyJWTApp.Back.Core.Application.Features.CQRS.Commands;
using UdemyJWTApp.Back.Core.Application.Interfaces;
using UdemyJWTApp.Back.Core.Domain;

namespace UdemyJWTApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class DeleteProductCommandRequestHandler : IRequestHandler<DeleteProudctCommandRequest>
    {
        private readonly IRepository<Product> _repository;

        public DeleteProductCommandRequestHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteProudctCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.Remove(request.Id);
            return Unit.Value;
        }
    }
}
