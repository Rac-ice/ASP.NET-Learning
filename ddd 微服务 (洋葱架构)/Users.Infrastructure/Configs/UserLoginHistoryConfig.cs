using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Users.Domain.Entities;

namespace Users.Infrastructure.Configs
{
    internal class UserLoginHistoryConfig : IEntityTypeConfiguration<UserLoginHistory>
    {
        public void Configure(EntityTypeBuilder<UserLoginHistory> builder)
        {
            builder.ToTable("T_UserLoginHistories");
            builder.OwnsOne(x => x.PhoneNumber, nb =>
            {
                nb.Property(x=>x.RegionCode).HasMaxLength(8).IsUnicode(false);
                nb.Property(x=>x.Number).HasMaxLength(32).IsUnicode(false);
            });
        }
    }
}
