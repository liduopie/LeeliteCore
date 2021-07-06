using Leelite.Framework.Service.Dtos;

namespace Leelite.Modules.Message.Models.MessageTypeAgg.Dtos.MessageTypeDtos
{
    public class MessageTypeUpdateRequest : IUpdateRequest<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Icon { get; set; }

        public string TitleTemplate { get; set; }

        public string DescriptionTemplate { get; set; }

        public string Schema { get; set; }

        public PushStrategy PushStrategy { get; set; }

        public string PushPlatform { get; set; }

        public int ValidDays { get; set; }

        public bool IsEnabled { get; set; }

    }
}
