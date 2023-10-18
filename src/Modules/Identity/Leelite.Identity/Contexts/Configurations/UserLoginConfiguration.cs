using Leelite.Identity.Models.UserLoginAgg;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leelite.Identity.Contexts.Configurations
{
    public class UserLoginConfiguration : IEntityTypeConfiguration<UserLogin>
    {
        private readonly StoreOptions _storeOptions;
        public UserLoginConfiguration(StoreOptions storeOptions)
        {
            _storeOptions = storeOptions;
        }

        public void Configure(EntityTypeBuilder<UserLogin> builder)
        {
            builder.Ignore("Id");
            builder.HasKey(c => new { c.LoginProvider, c.ProviderKey });
            builder.ToTable(TableConsts.IdentityUserLogins);

            if (_storeOptions.MaxLengthForKeys > 0)
            {
                builder.Property(c => c.LoginProvider).HasMaxLength(_storeOptions.MaxLengthForKeys);
                builder.Property(c => c.ProviderKey).HasMaxLength(_storeOptions.MaxLengthForKeys);
            }

            builder.Property(l => l.ProviderDisplayName).HasMaxLength(256);
        }
    }
}
