using FluentValidation;
using UdemyJWTApp.Back.Core.Application.Dto;

namespace UdemyJWTApp.Back.Core.Application.ValidationRules.CategoryRules
{
    public class UpdateCategoryRule : AbstractValidator<CategoryUpdateDto>
    {
        public UpdateCategoryRule()
        {
            RuleFor(x => x.Description).NotNull().MaximumLength(250);
        }
    }
}
