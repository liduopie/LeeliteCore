using Leelite.Framework.Domain.Aggregate;
using Leelite.Framework.Models.Enabled;

namespace Leelite.Modules.Message.Models.MessageTypeAgg
{
    /// <summary>
    /// 消息类型
    /// </summary>
    public class MessageType : AggregateRoot<int>,
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
        /// 消息标题模板,模版中包含话术及用户名称占位符{{Nick}}
        /// </summary>
        public string TitleTemplate { get; set; }

        /// <summary>
        /// 消息描述模版,模版中包含话术及用户名称占位符{{Nick}}
        /// </summary>
        public string DescriptionTemplate { get; set; }

        /// <summary>
        /// 数据结构描述
        /// </summary>
        public string Schema { get; set; }

        /// <summary>
        /// 推送策略
        /// </summary>
        public PushStrategy PushStrategy { get; set; }

        /// <summary>
        /// 推送平台,平台名称: XXX,XXX
        /// </summary>
        public string PushPlatform { get; set; }

        /// <summary>
        /// 消息有效时间（单位：天）
        /// </summary>
        public int ValidDays { get; set; }

        /// <summary>
        /// 消息类型不启用，系统将不接受和存储该类型消息
        /// </summary>
        public bool IsEnabled { get; set; }
    }
}
