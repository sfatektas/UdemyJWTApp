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
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandRequestHandler(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UpdateCategoryCommandResult> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
           await _repository.UpdateEntity(_mapper.Map<Category>(request));
            return new(ResponseType.Success);
        }
    }
}
