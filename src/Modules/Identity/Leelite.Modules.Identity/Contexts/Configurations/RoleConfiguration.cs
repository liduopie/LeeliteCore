using Leelite.Modules.Identity.Models.RoleAgg;
using Leelite.Modules.Identity.Models.RoleClaimAgg;
using Leelite.Modules.Identity.Models.UserRoleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leelite.Modules.Identity.Contexts.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(r => r.Id);
            builder.HasIndex(r => r.NormalizedName).HasDatabaseName("RoleNameIndex").IsUnique();
            builder.ToTable(TableConsts.IdentityRoles);

            builder.Property(r => r.ConcurrencyStamp).HasMaxLength(256).IsConcurrencyToken();

            builder.Property(r => r.Name).HasMaxLength(256);
            builder.Property(r => r.NormalizedName).HasMaxLength(256);
            builder.Property(r => r.Description).HasMaxLength(1024);

            builder.HasMany<UserRole>().WithOne().HasForeignKey("_roleId").IsRequired();
            builder.HasMany<RoleClaim>().WithOne().HasForeignKey(rc => rc.RoleId).IsRequired();
        }
    }
}
