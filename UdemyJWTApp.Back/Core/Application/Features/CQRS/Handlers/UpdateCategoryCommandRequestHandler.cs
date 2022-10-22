using AutoMapper;
using MediatR;
using UdemyJWTApp.Back.Core.Application.Features.CQRS.Commands;
using UdemyJWTApp.Back.Core.Application.Features.CQRS.Results;
using UdemyJWTApp.Back.Core.Application.Interfaces;
using UdemyJWTApp.Back.Core.Domain;

namespace UdemyJWTApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class UpdateCategoryCommandRequestHandler : IRequestHandler<UpdateCategoryCommandRequest, UpdateCategoryCommandResult>
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;

        public UpdateCategoryCommandRequestHandler(IMapper mapper, IUow uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<UpdateCategoryCommandResult> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            await _uow.GetRepository<Category>().UpdateEntity(_mapper.Map<Category>(request));
            await _uow.SaveChangesAsync();
            return new(ResponseType.Success);
        }
    }
}
