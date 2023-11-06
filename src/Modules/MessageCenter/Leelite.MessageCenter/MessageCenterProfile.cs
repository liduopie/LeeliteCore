using AutoMapper;

using Leelite.MessageCenter.Dtos.MessageDtos;
using Leelite.MessageCenter.Dtos.MessageTypeDtos;
using Leelite.MessageCenter.Dtos.PushPlatformDtos;
using Leelite.MessageCenter.Dtos.PushRecordDtos;
using Leelite.MessageCenter.Dtos.SessionDtos;
using Leelite.MessageCenter.Dtos.TemplateDtos;
using Leelite.MessageCenter.Models.MessageAgg;
using Leelite.MessageCenter.Models.MessageTypeAgg;
using Leelite.MessageCenter.Models.PushPlatformAgg;
using Leelite.MessageCenter.Models.PushRecordAgg;
using Leelite.MessageCenter.Models.SessionAgg;
using Leelite.MessageCenter.Models.TemplateAgg;

namespace Leelite.MessageCenter
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
            CreateMap<SessionDto, Session>();
            CreateMap<SessionCreateRequest, Session>();
            CreateMap<SessionUpdateRequest, Session>();

            CreateMap<Template, TemplateDto>();
            CreateMap<TemplateCreateRequest, Template>();
            CreateMap<TemplateUpdateRequest, Template>();
        }
    }
}
