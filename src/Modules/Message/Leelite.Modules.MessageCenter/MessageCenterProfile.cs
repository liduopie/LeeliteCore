using AutoMapper;
using Leelite.Modules.MessageCenter.Dtos.MessageDtos;
using Leelite.Modules.MessageCenter.Dtos.MessageTypeDtos;
using Leelite.Modules.MessageCenter.Dtos.PushPlatformDtos;
using Leelite.Modules.MessageCenter.Dtos.PushRecordDtos;
using Leelite.Modules.MessageCenter.Dtos.SessionDtos;
using Leelite.Modules.MessageCenter.Dtos.TemplateDtos;
using Leelite.Modules.MessageCenter.Models.MessageAgg;
using Leelite.Modules.MessageCenter.Models.MessageTypeAgg;
using Leelite.Modules.MessageCenter.Models.PlatformAgg;
using Leelite.Modules.MessageCenter.Models.PushRecordAgg;
using Leelite.Modules.MessageCenter.Models.SessionAgg;
using Leelite.Modules.MessageCenter.Models.TemplateAgg;

namespace Leelite.Modules.MessageCenter
{
    public class MessageCenterProfile : Profile
    {
        public MessageCenterProfile()
        {
            CreateMap<Message, MessageDto>();
            CreateMap<MessageCreateRequest, Message>();
            CreateMap<MessageUpdateRequest, Message>();

            CreateMap<MessageType, MessageTypeDto>();
            CreateMap<MessageTypeCreateRequest, MessageType>();
            CreateMap<MessageTypeUpdateRequest, MessageType>();

            CreateMap<PushPlatform, PushPlatformDto>();
            CreateMap<PushPlatformCreateRequest, PushPlatform>();
            CreateMap<PushPlatformUpdateRequest, PushPlatform>();

            CreateMap<PushRecord, PushRecordDto>();
            CreateMap<PushRecordCreateRequest, PushRecord>();
            CreateMap<PushRecordUpdateRequest, PushRecord>();

            CreateMap<Session, SessionDto>();
            CreateMap<SessionCreateRequest, Session>();
            CreateMap<SessionUpdateRequest, Session>();

            CreateMap<Template, TemplateDto>();
            CreateMap<TemplateCreateRequest, Template>();
            CreateMap<TemplateUpdateRequest, Template>();
        }
    }
}
