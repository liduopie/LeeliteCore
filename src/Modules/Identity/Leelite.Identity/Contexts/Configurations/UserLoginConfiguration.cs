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
            builder.HasKey("_loginProvider", "_providerKey");
            builder.ToTable(TableConsts.IdentityUserLogins);

            if (_storeOptions.MaxLengthForKeys > 0)
            {
                builder.Property("_loginProvider").HasColumnName("LoginProvider").HasMaxLength(_storeOptions.MaxLengthForKeys);
                builder.Property("_providerKey").HasColumnName("ProviderKey").HasMaxLength(_storeOptions.MaxLengthForKeys);
            }

            builder.Property(l => l.ProviderDisplayName).HasMaxLength(256);
        }
    }
}
