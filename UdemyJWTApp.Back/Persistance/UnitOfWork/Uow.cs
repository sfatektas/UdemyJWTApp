using UdemyJWTApp.Back.Core.Application.Interfaces;
using UdemyJWTApp.Back.Core.Domain;
using UdemyJWTApp.Back.Persistance.Context;
using UdemyJWTApp.Back.Persistance.Repositories;

namespace UdemyJWTApp.Back.Persistance.UnitOfWork
{
    public class Uow : IUow
    {
        private readonly UdemyJWTDbContext _context;

        public Uow(UdemyJWTDbContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity , new()
        {
            return new Repository<T>(_context);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
