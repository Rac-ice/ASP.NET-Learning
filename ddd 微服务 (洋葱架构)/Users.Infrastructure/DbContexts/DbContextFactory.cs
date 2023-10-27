using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Users.Infrastructure.DbContexts
{
    public class DbContextFactory : IDesignTimeDbContextFactory<UserDbContext>
    {
        public UserDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<UserDbContext>();
            builder.UseSqlServer("server=.;database=dddDemo;uid=sa;pwd=271016;Trusted_Connection=True;TrustServerCertificate=True;");
            return new UserDbContext(builder.Options);
        }
    }
}
