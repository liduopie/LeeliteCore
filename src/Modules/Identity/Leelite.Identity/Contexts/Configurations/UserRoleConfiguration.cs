using Leelite.Identity.Models.UserRoleAgg;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leelite.Identity.Contexts.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.Ignore("Id");
            builder.HasKey(c => new { c.UserId, c.RoleId });
            builder.ToTable(TableConsts.IdentityUserRoles);
        }
    }
}
