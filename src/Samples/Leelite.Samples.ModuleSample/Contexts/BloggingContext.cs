using Leelite.Framework.Domain.Context;
using Leelite.Samples.ModuleSample.Models.BlogAgg;
using Microsoft.EntityFrameworkCore;

namespace Leelite.Samples.ModuleSample.Contexts
{
    public class BloggingContext : EFDbContext
    {
        public BloggingContext(DbContextOptions<BloggingContext> options) : base(options) { }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
