using System.Linq.Expressions;
using UdemyJWTApp.Back.Core.Domain;

namespace UdemyJWTApp.Back.Core.Application.Interfaces
{
    public interface IRepository<T> where T : BaseEntity 
    {
        Task<List<T>> GetAllAsync();

        Task<List<T>> GetByFilterAsync(Expression<Func<T,bool>> filter);

        Task<T> GetOneByFileterAsync(Expression<Func<T, bool>> filter);

        Task<T> GetByIdAsync(int id);

        Task CreateEntity(T entity);

        Task UpdateEntity(T entity);

        Task Remove(int id);

        IQueryable<T> GetQueryable();
    }
}
