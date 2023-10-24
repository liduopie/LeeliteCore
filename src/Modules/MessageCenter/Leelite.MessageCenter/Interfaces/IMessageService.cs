using System.Collections.Generic;

using Leelite.Framework.Service;
using Leelite.MessageCenter.Dtos.MessageDtos;
using Leelite.MessageCenter.Models.MessageAgg;

namespace Leelite.MessageCenter.Interfaces
{
    public interface IMessageService : ICrudService<Message, long, MessageDto, MessageCreateRequest, MessageUpdateRequest, MessageQueryParameter>
    {
        public IList<MessageUserReadCount> GetUserUnReadCount(long userId);

        /// <summary>
        /// 消息送达状态
        /// </summary>
        /// <param name="id"></param>
        public void Delivered(long id);

        /// <summary>
        /// 消息生成推送记录
        /// </summary>
        /// <param name="id"></param>
        public void GenerateRecord(long id);
    }
}
