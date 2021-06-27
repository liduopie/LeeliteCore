using Leelite.Framework.Domain.Aggregate;
using Leelite.Framework.Models.SoftDelete;

using System;
using System.Collections.Generic;
using System.Text;

namespace Leelite.Modules.Message.Models.MessageAgg
{
    public class Message : AggregateRoot<long>,
        ISoftDelete
    {
        /// <summary>
        /// 用户标识
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        public int MessageTypeId { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 描述信息
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 内容数据Json格式
        /// </summary>
        public string ContentData { get; set; }

        /// <inheritdoc/>
        public bool IsDeleted { get; set; }
    }
}
