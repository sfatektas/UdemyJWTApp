using MediatR;
using UdemyJWTApp.Back.Core.Application.Features.CQRS.Commands;
using UdemyJWTApp.Back.Core.Application.Interfaces;
using UdemyJWTApp.Back.Core.Domain;
using UdemyJWTApp.Back.Persistance.Context;

namespace UdemyJWTApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class DeleteCategoryCommandRequestHandler : IRequestHandler<DeleteCategoryCommandRequest>
    {
        private readonly IUow _uow;

        public DeleteCategoryCommandRequestHandler(IUow uow)
        {
            _uow = uow;
        }

        public async Task<Unit> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var deleteProducts = _uow.GetRepository<Product>().GetQueryable().Where(x => x.CategoryId == request.Id);

            foreach (var item in deleteProducts)
            {
                await _uow.GetRepository<Product>().Remove(item.Id);
            }
            //
            await _uow.GetRepository<Category>().Remove(request.Id);
            await _uow.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
