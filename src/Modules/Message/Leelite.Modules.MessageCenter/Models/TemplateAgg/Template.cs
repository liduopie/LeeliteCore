using System;
using System.Collections.Generic;
using System.Text;
using Leelite.Framework.Domain.Aggregate;

namespace Leelite.Modules.MessageCenter.Models.TemplateAgg
{
    /// <summary>
    /// 消息模版
    /// </summary>
    public class Template : AggregateRoot<long>
    {
        /// <summary>
        /// 平台Id
        /// </summary>
        public int PlatformId { get; set; }

        /// <summary>
        /// 消息类型编码
        /// </summary>
        public string MessageTypeCode { get; set; }

        /// <summary>
        /// 模版名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 模版描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 第三方模版编码
        /// </summary>
        public string TemplateCode { get; set; }

        /// <summary>
        /// 内容模版
        /// 使用StringTemplate进行渲染
        /// </summary>
        public string ContentTemplate { get; set; }

        /// <summary>
        /// 链接模版
        /// 使用StringTemplate进行渲染
        /// </summary>
        public string UrlTemplate { get; set; }
    }
}
