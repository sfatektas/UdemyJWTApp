using FluentValidation;
using UdemyJWTApp.Back.Core.Application.Dto;

namespace UdemyJWTApp.Back.Core.Application.ValidationRules.ProductRules
{
    public class UpdateProductRule : AbstractValidator<ProductUpdateDto>
    {
        public UpdateProductRule()
        {
            RuleFor(x => x.CategoryId).NotEmpty();
            RuleFor(x => x.CategoryId).Must(x => x > 0 && x.GetType() == typeof(int)).WithMessage("0 dan büyük bir numerik değer almalıdır.");
            RuleFor(x => x.Price).NotEmpty();
            RuleFor(x => x.Description).NotEmpty().Must(x => x.Length < 200).WithMessage("Ürün adı maximum 200 karakter olmalıdır.");
            RuleFor(x => x.Stock).Must(x => x >= 0).WithMessage("Stock değeri 0 dan büyük olmalıdır.");
        }

    }
}
