using System;
using System.Data;
using System.Linq;
using Leelite.Framework.Domain.Context;
using Leelite.Identity.Contexts.Configurations;
using Leelite.Identity.Models.RoleAgg;
using Leelite.Identity.Models.RoleClaimAgg;
using Leelite.Identity.Models.UserAgg;
using Leelite.Identity.Models.UserClaimAgg;
using Leelite.Identity.Models.UserFingerprintAgg;
using Leelite.Identity.Models.UserKeyAgg;
using Leelite.Identity.Models.UserLoginAgg;
using Leelite.Identity.Models.UserRoleAgg;
using Leelite.Identity.Models.UserTokenAgg;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Leelite.Identity.Contexts
{
    public class IdentityContext : EFDbContext
    {
        private IdentityOptions _identityOptions;
        public IdentityContext(DbContextOptions<IdentityContext> options, IOptions<IdentityOptions> identityOptions) : base(options)
        {
            _identityOptions = identityOptions.Value;
        }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TEntity}"/> of Users.
        /// </summary>
        public virtual DbSet<User> Users { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TEntity}"/> of User claims.
        /// </summary>
        public virtual DbSet<UserClaim> UserClaims { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TEntity}"/> of User fingerprints.
        /// </summary>
        public virtual DbSet<UserFingerprint> UserFingerprints { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TEntity}"/> of User keys.
        /// </summary>
        public virtual DbSet<UserKey> UserKeys { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TEntity}"/> of User logins.
        /// </summary>
        public virtual DbSet<UserLogin> UserLogins { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TEntity}"/> of User tokens.
        /// </summary>
        public virtual DbSet<UserToken> UserTokens { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TEntity}"/> of User roles.
        /// </summary>
        public virtual DbSet<UserRole> UserRoles { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TEntity}"/> of roles.
        /// </summary>
        public virtual DbSet<Role> Roles { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TEntity}"/> of role claims.
        /// </summary>
        public virtual DbSet<RoleClaim> RoleClaims { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var storeOptions = _identityOptions.Stores;
            var maxKeyLength = storeOptions?.MaxLengthForKeys ?? 0;
            var encryptPersonalData = storeOptions?.ProtectPersonalData ?? false;
            PersonalDataConverter converter = null;

            if (storeOptions.ProtectPersonalData)
            {
                converter = new PersonalDataConverter(this.GetService<IPersonalDataProtector>());
            }

            builder.ApplyConfiguration(new UserConfiguration(storeOptions, converter));
            builder.ApplyConfiguration(new UserClaimConfiguration());
            builder.ApplyConfiguration(new UserFingerprintConfiguration());
            builder.ApplyConfiguration(new UserKeyConfiguration());
            builder.ApplyConfiguration(new UserLoginConfiguration(storeOptions));
            builder.ApplyConfiguration(new UserTokenConfiguration(storeOptions, converter));
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new RoleClaimConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
        }
    }
}
