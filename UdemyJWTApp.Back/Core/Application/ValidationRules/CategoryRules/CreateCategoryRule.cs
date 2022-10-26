using FluentValidation;
using UdemyJWTApp.Back.Core.Application.Dto;

namespace UdemyJWTApp.Back.Core.Application.ValidationRules.CategoryRules
{
    public class CreateCategoryRule : AbstractValidator<CategoryCreateDto>
    {
        public CreateCategoryRule()
        {
            RuleFor(x => x.Description).NotEmpty().MaximumLength(250);
        }
    }
}
