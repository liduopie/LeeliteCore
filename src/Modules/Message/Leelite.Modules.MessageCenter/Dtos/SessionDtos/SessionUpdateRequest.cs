using Leelite.Framework.Service.Dtos;
using Leelite.Modules.MessageCenter.Models.SessionAgg;
using System;
using System.Collections.Generic;

namespace Leelite.Modules.MessageCenter.Dtos.SessionDtos
{
    public class SessionUpdateRequest : IUpdateRequest<long>
    {
        public long Id { get; set; }

        public int MessageTypeId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public IDictionary<string, string> Data { get; set; }

        public IList<long> UserIds { get; set; }

        public int UserNum { get; set; }

        public int PushNum { get; set; }

        public DateTime CreateTime { get; set; }

        public CompleteState State { get; set; }

        public DateTime CompleteTime { get; set; }

        public DateTime ExpirationTime { get; set; }

        public string Remark { get; set; }

    }
}
