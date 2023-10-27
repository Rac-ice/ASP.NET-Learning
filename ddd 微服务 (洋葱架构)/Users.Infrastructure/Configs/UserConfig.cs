using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Users.Domain.Entities;

namespace Users.Infrastructure.Configs
{
    internal class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("T_Users");
            builder.OwnsOne(x => x.PhoneNumber, nb =>
            {
                nb.Property(x=>x.RegionCode).HasMaxLength(8).IsUnicode(false);
                nb.Property(x=>x.Number).HasMaxLength(32).IsUnicode(false);
            });
            builder.Property("passwordHash").HasMaxLength(128).IsUnicode(false);
            builder.HasOne(x => x.UserAccessFail).WithOne(x => x.User)
                .HasForeignKey<UserAccessFail>(x => x.UserId);
        }
    }
}
