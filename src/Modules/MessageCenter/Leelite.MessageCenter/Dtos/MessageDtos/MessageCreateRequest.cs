using System;

using Leelite.Framework.Service.Dtos;

namespace Leelite.MessageCenter.Dtos.MessageDtos
{
    public class MessageCreateRequest : IRequest
    {
        public long UserId { get; set; }

        public int MessageTypeId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Data { get; set; }

        public bool ReadState { get; set; }

        public bool DeliveryState { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime ReadTime { get; set; }

        public DateTime DeleteTime { get; set; }

        public DateTime ExpirationTime { get; set; }

    }
}
