using System;
using System.Collections.Generic;

using Leelite.Framework.Service.Dtos;
using Leelite.MessageCenter.Models.SessionAgg;

namespace Leelite.MessageCenter.Dtos.SessionDtos
{
    public class SessionCreateRequest : IRequest
    {
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
