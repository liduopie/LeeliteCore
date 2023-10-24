using System;
using System.Linq;

using Leelite.Framework.Data.Query.Criteria;
using Leelite.Framework.Data.Query.RangeCriteria;

namespace Leelite.MessageCenter.Models.SessionAgg
{
    public static class SessionCriteria
    {
        /// <summary>
        /// 关键字查询，在标题和描述中匹配
        /// </summary>
        /// <param name="keyword">搜索关键字</param>
        /// <returns></returns>
        public static Criterion<Session> Keyword(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return new TrueCriterion<Session>();

            keyword = keyword.ToLower();

            var titleCriterion = new DirectCriterion<Session>(c => c.Title.Contains(keyword));
            var descriptionCriterion = new DirectCriterion<Session>(c => c.Description.Contains(keyword));

            var criterion = titleCriterion && descriptionCriterion;

            return criterion;
        }

        /// <summary>
        /// 按照创建时间区间匹配
        /// </summary>
        /// <param name="start">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <returns></returns>
        public static Criterion<Session> CreateTimeRange(DateTime start, DateTime end)
        {
            return new DateTimeRangeCriterion<Session, DateTime>(c => c.CreateTime, start, end);
        }

        /// <summary>
        /// 按照状态匹配
        /// </summary>
        /// <param name="states">状态集合</param>
        /// <returns></returns>
        public static Criterion<Session> CompleteStates(CompleteState[] states)
        {
            return new DirectCriterion<Session>(c => states.Contains(c.State));
        }

        /// <summary>
        /// 过期、未过期
        /// </summary>
        /// <returns></returns>
        public static Criterion<Session> Expired(bool state)
        {
            if (state)
                return new DirectCriterion<Session>(c => c.ExpirationTime < DateTime.Now);
            else
                return new DirectCriterion<Session>(c => c.ExpirationTime >= DateTime.Now);
        }
        /// <summary>
        /// 类型ID
        /// </summary>
        /// <returns></returns>
        public static Criterion<Session> MessageType(int MessageTypeId)
        {
            return new DirectCriterion<Session>(c => c.MessageTypeId == MessageTypeId);
        }
    }
}
