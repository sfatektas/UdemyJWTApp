using UdemyJWTApp.Back.Core.Domain;
using UdemyJWTApp.Back.Persistance.Repositories;

namespace UdemyJWTApp.Back.Core.Application.Interfaces
{
    public interface IUow
    {
        public IRepository<T> GetRepository<T>() where T : BaseEntity,new();

        public Task SaveChangesAsync();
    }
}
