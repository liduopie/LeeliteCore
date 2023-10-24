using System;

using Leelite.Framework.Domain.Aggregate;
using Leelite.Framework.Models.State;

namespace Leelite.MessageCenter.Models.PushRecordAgg
{
    public class PushRecord : AggregateRoot<long>,
        IState<PushState>
    {
        /// <summary>
        /// 用户标识
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 消息Id
        /// </summary>
        public long MessageId { get; set; }

        /// <summary>
        /// 平台Id
        /// </summary>
        public int PlatformId { get; set; }

        /// <summary>
        /// 第三方模版编码
        /// </summary>
        public string TemplateCode { get; set; }

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
        public PushState State { get; set; }

        /// <summary>
        /// 重试次数
        /// </summary>
        public int RetriesNum { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime ExpirationTime { get; set; }
    }
}
