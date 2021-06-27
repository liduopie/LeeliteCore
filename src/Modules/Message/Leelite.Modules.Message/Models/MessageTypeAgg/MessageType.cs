using Leelite.Framework.Domain.Aggregate;

namespace Leelite.Modules.Message.Models.MessageTypeAgg
{
    public class MessageType : AggregateRoot<int>
    {
        /// <summary>
        /// 消息类型名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 类型编码
        /// </summary>
        public string TypeCode { get; set; }

        /// <summary>
        /// 消息模板
        /// </summary>
        public string Template { get; set; }
    }
}
