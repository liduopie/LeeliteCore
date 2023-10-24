using Leelite.Framework.Service.Dtos;

namespace Leelite.MessageCenter.Dtos.TemplateDtos
{
    public class TemplateCreateRequest : IRequest
    {
        public int PlatformId { get; set; }

        public string MessageTypeCode { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string TemplateCode { get; set; }

        public string ContentTemplate { get; set; }

        public string UrlTemplate { get; set; }

    }
}
