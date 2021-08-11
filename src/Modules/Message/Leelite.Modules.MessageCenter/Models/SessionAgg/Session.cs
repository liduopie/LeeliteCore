using System;
using System.Collections.Generic;
using System.Text;

using Leelite.Framework.Domain.Aggregate;
using Leelite.Framework.Models.Audit;
using Leelite.Framework.Models.State;

namespace Leelite.Modules.MessageCenter.Models.SessionAgg
{
    public class Session : AggregateRoot<long>,
        IState<CompleteState>
    {
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
        public IDictionary<string, string> Data { get; set; }

        /// <summary>
        /// 用户Id串
        /// </summary>
        public IList<long> UserIds { get; set; }

        /// <summary>
        /// 用户数量
        /// </summary>
        public int UserNum { get; set; }

        /// <summary>
        /// 推送数量
        /// </summary>
        public int PushNum { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 完成状态
        /// </summary>
        public CompleteState State { get; set; }

        /// <summary>
        /// 完成时间
        /// </summary>
        public DateTime CompleteTime { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime ExpirationTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
