using Leelite.Framework.Service.Dtos;

namespace Leelite.Samples.ModuleSample.Dtos
{
    public class BlogDto : IDto<int>
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int Rating { get; set; }
        public bool? IsEnabled { get; set; }
    }
}
