using Leelite.Framework.Service.Dtos;
using Leelite.Modules.MessageCenter.Models.MessageTypeAgg;

using System.Collections.Generic;

namespace Leelite.Modules.MessageCenter.Dtos.MessageTypeDtos
{
    public class MessageTypeCreateRequest : IRequest
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public string Icon { get; set; }

        public string TitleTemplate { get; set; }

        public string DescriptionTemplate { get; set; }

        public string Schema { get; set; }

        public PushStrategy PushStrategy { get; set; }

        public IList<string> PushPlatform { get; set; }

        public int ValidDays { get; set; }

        public bool IsEnabled { get; set; }

    }
}
