using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UdemyJWTApp.Back.Core.Application.Interfaces;
using UdemyJWTApp.Back.Core.Domain;
using UdemyJWTApp.Back.Persistance.Context;

namespace UdemyJWTApp.Back.Persistance.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity,new()
    {
        private readonly UdemyJWTDbContext _context;

        public Repository(UdemyJWTDbContext context)
        {
            _context = context;
        }
        public async Task CreateEntity(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().Where(filter).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var result = await _context.Set<T>().SingleOrDefaultAsync(x => x.Id == id);
            return result == null ? new T() { } : result;
        }

        public async Task Remove(int id)
        {
            var entity = await this.GetByIdAsync(id);
             _context.Remove(entity);
            await _context.SaveChangesAsync();

        }

        public async Task UpdateEntity(T entity)
        {
            var unchanged = await this.GetByIdAsync(entity.Id);
            _context.Entry(unchanged).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
        }
    }
}
