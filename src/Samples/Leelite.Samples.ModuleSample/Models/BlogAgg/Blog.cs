using System.Collections.Generic;
using Leelite.Framework.Domain.Aggregate;
using Leelite.Framework.Models.Enabled;

namespace Leelite.Samples.ModuleSample.Models.BlogAgg
{
    public class Blog : AggregateRoot<int>, IEnabled
    {
        public string Url { get; set; }
        public int Rating { get; set; }
        public List<Post> Posts { get; set; }
        public bool IsEnabled { get; set; }
    }
}
