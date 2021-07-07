using Leelite.Framework.Service.Dtos;
using Leelite.Modules.Message.Models.SessionAgg;
using System;

namespace Leelite.Modules.Message.Dtos.SessionDtos
{
    public class SessionCreateRequest : IRequest
    {
        public int MessageTypeId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Data { get; set; }

        public string UserIds { get; set; }

        public int UserNum { get; set; }

        public int PushNum { get; set; }

        public DateTime CreateTime { get; set; }

        public CompleteState State { get; set; }

        public DateTime CompleteTime { get; set; }

        public DateTime ExpirationTime { get; set; }

        public string Remark { get; set; }

    }
}
