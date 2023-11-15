using Leelite.DataDictionary.Contexts.Configurations;
using Leelite.DataDictionary.Models.DataItemAgg;
using Leelite.DataDictionary.Models.DataTypeAgg;
using Leelite.Framework.Domain.Context;

using Microsoft.EntityFrameworkCore;

namespace Leelite.DataDictionary.Contexts
{
    public class DataDictionaryContext : EFDbContext
    {
        public DataDictionaryContext(DbContextOptions<DataDictionaryContext> options) : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TEntity}"/> of DataItem.
        /// </summary>
        public virtual DbSet<DataItem> DataItems { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TEntity}"/> of Users.
        /// </summary>
        public virtual DbSet<DataType> DataTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new DataItemConfiguration());
            builder.ApplyConfiguration(new DataTypeConfiguration());
        }
    }
}
