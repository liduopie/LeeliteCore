using Leelite.Modules.Identity.Models.UserRoleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leelite.Modules.Identity.Contexts.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.Ignore("Id");
            builder.HasKey("_userId", "_roleId");
            builder.ToTable(TableConsts.IdentityUserRoles);

            builder.Property("_userId").HasColumnName("UserId");
            builder.Property("_roleId").HasColumnName("RoleId");
        }
    }
}
