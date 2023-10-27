using Microsoft.EntityFrameworkCore;
using Users.Domain.Entities;

namespace Users.Infrastructure.DbContexts
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; private set; }
        public DbSet<UserLoginHistory> UserLoginHistories { get; private set; }

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
