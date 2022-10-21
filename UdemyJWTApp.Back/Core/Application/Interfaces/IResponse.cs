namespace UdemyJWTApp.Back.Core.Application.Interfaces
{
    public interface IResponse
    {
        public ResponseType ResponseType { get; set; }
    }
    public enum ResponseType
    {
        Success,
        NotFound
    }
}
