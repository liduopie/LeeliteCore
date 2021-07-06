using Leelite.Framework.Service.Dtos;

using System;

namespace Leelite.Modules.Message.Models.SessionAgg.Dtos.SessionDtos
{
    public class SessionUpdateRequest : IUpdateRequest<long>
    {
        public long Id { get; set; }

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
