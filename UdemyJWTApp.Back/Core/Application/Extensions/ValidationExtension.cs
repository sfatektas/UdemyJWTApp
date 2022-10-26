using FluentValidation.Results;

namespace UdemyJWTApp.Back.Core.Application.Extensions
{
    public static class ValidationExtension
    {
        public static Dictionary<string,string> GetErrorMessages(this ValidationResult result)
        {
            Dictionary<string,string> errors = new Dictionary<string,string>();
            foreach (var error in result.Errors)
            {
                errors.Add(error.PropertyName, error.ErrorMessage);
            }
            return errors;
        }
    }
}
