namespace UdemyJWTApp.Back.Core.Application.Interfaces
{
    public interface IResponse<T> : IResponse where T : class
    {
        public T ResponseData { get; set; }
    }
}
