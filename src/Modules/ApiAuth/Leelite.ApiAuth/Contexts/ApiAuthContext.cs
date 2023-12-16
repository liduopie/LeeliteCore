using Leelite.ApiAuth.Contexts.Configurations;
using Leelite.ApiAuth.Models.ApiKeyAgg;
using Leelite.Framework.Domain.Context;

using Microsoft.EntityFrameworkCore;

namespace Leelite.ApiAuth.Contexts
{
    public class ApiAuthContext : EFDbContext
    {
        public ApiAuthContext(DbContextOptions<ApiAuthContext> options) : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TEntity}"/> of ApiKeys.
        /// </summary>
        public virtual DbSet<ApiKey> ApiKeys { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ApiKeyConfiguration());
        }
    }
}
