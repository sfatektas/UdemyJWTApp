using FluentValidation;
using UdemyJWTApp.Back.Core.Application.Dto;

namespace UdemyJWTApp.Back.Core.Application.ValidationRules.ProductRules
{
    public class CreateProductRule : AbstractValidator<ProductCreateDto>
    {
        public CreateProductRule()
        {
            RuleFor(x => x.CategoryId).NotEmpty();
            RuleFor(x => x.CategoryId).Must(x=>x>0 && x<5).WithMessage("0 dan büyük 5 den küçük bir numerik değer almalıdır."); 
            RuleFor(x => x.Price).NotEmpty();
            RuleFor(x => x.Description).NotEmpty().Must(x=>x.Length <200).WithMessage("Ürün adı maximum 200 karakter olmalıdır.");
            RuleFor(x => x.Stock).Must(x => x > 0).WithMessage("Stock değeri 0 dan büyük olmalıdır.");
        }
    }
}
