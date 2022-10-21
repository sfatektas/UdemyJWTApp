using Microsoft.EntityFrameworkCore;
using UdemyJWTApp.Back.Core.Domain;
using UdemyJWTApp.Back.Persistance.Configurations;

namespace UdemyJWTApp.Back.Persistance.Context
{
    public class UdemyJWTDbContext : DbContext
    {
        public UdemyJWTDbContext(DbContextOptions<UdemyJWTDbContext> options) : base(options)
        {
                
        }

        public DbSet<Product> Products {
            get 
            {
            return this.Set<Product>(); 
            } 
        }
        public DbSet<AppRole> AppRoles { 
            get
            {
                return this.Set<AppRole>(); 
            }
        }
        public DbSet<AppUser> AppUsers
        {
            get
            {
                return this.Set<AppUser>();
            }
        }
        public DbSet<Category> Categories 
        {
            get
            {
                return this.Set<Category>();
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}
