using Leelite.Framework.Domain.Model;

namespace Leelite.Samples.ModuleSample.Models.BlogAgg
{
    public class Post : Entity<int>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
