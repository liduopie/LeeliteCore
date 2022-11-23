using Leelite.Framework.Domain.Aggregate;
using Leelite.Framework.Models.Enabled;

namespace Leelite.Modules.MessageCenter.Models.MessageTopicAgg
{
    /// <summary>
    /// 消息主题
    /// </summary>
    public class MessageTopic : AggregateRoot<int>,
        IEnabled
    {

        /// <summary>
        /// 消息类型名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 类型编码 xxx.xxx.xxx
        /// 需要唯一索引
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }


        /// <summary>
        /// 消息主题不启用，前端查询将不输出消息
        /// </summary>
        public bool IsEnabled { get; set; }
    }
}
