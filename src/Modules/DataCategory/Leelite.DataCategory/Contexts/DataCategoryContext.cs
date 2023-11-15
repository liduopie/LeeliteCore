using Leelite.DataCategory.Contexts.Configurations;
using Leelite.DataCategory.Models.CategoryAgg;
using Leelite.DataCategory.Models.CategoryTypeAgg;
using Leelite.Framework.Domain.Context;

using Microsoft.EntityFrameworkCore;

namespace Leelite.DataCategory.Contexts
{
    public class DataCategoryContext : EFDbContext
    {
        public DataCategoryContext(DbContextOptions<DataCategoryContext> options) : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TEntity}"/> of Users.
        /// </summary>
        public virtual DbSet<Category> Categories { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TEntity}"/> of Users.
        /// </summary>
        public virtual DbSet<CategoryType> CategoryTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new CategoryTypeConfiguration());
        }
    }
}
