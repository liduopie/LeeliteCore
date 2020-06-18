using Leelite.Framework.Models.Enabled;
using Leelite.Framework.Service.Dtos;

namespace Leelite.Samples.ModuleSample.Dtos
{
    public class BlogCreateRequest : IRequest, IEnabledParameter
    {
        public string Url { get; set; }
        public int Rating { get; set; }
        public bool? IsEnabled { get; set; }
    }
}
