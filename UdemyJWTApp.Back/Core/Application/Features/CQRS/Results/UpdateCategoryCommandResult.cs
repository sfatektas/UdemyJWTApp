using UdemyJWTApp.Back.Core.Application.Interfaces;

namespace UdemyJWTApp.Back.Core.Application.Features.CQRS.Results
{
    public class UpdateCategoryCommandResult : IResponse
    {
        //Response yapısını denemek için bir tane oluşturdum

        public ResponseType ResponseType { get ; set ; }

        public UpdateCategoryCommandResult(ResponseType responseType)
        {
            ResponseType = responseType;
        }
    }
}
