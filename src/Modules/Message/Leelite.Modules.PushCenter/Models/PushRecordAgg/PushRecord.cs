using System;
using Leelite.Framework.Domain.Aggregate;

namespace Leelite.Modules.PushCenter.Models.PushRecordAgg
{
    public class PushRecord : AggregateRoot<long>
    {
        /// <summary>
        /// 消息Id
        /// </summary>
        public long MessageId { get; set; }

        /// <summary>
        /// 平台Id
        /// </summary>
        public int PlatformId { get; set; }

        /// <summary>
        /// 推送内容
        /// 内容是通过模版按照对应平台要求渲染后的数据
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 跳转链接
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 推送状态
        /// </summary>
        public bool PushState { get; set; }

        /// <summary>
        /// 重试次数
        /// </summary>
        public int RetriesNum { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
