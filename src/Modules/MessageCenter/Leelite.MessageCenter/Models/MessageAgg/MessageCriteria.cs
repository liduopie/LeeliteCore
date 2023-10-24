using System;

using Leelite.Framework.Data.Query.Criteria;
using Leelite.Framework.Data.Query.RangeCriteria;
using Leelite.Framework.Models.SoftDelete;

namespace Leelite.MessageCenter.Models.MessageAgg
{
    public static class MessageCriteria
    {
        /// <summary>
        /// 按照关键字匹配
        /// </summary>
        /// <param name="keyword">关键字</param>
        /// <returns>返回关键</returns>
        public static Criterion<Message> Keyword(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return new TrueCriterion<Message>();

            keyword = keyword.ToLower();

            var titleCriterion = new DirectCriterion<Message>(c => c.Title.Contains(keyword));
            var descriptionCriterion = new DirectCriterion<Message>(c => c.Description.Contains(keyword));

            var criterion = titleCriterion && descriptionCriterion;

            return criterion;
        }
        public static Criterion<Message> MessageType(int messageTypeId)
        {
            if (messageTypeId <= 0)
                return new TrueCriterion<Message>();

            var urlCriterion = new DirectCriterion<Message>(c => c.MessageTypeId == messageTypeId);

            return urlCriterion;
        }

        /// <summary>
        /// 按照创建时间区间匹配
        /// </summary>
        /// <param name="start">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <returns>返回创建时间区间条件</returns>
        public static Criterion<Message> CreateTimeRange(DateTime start, DateTime end)
        {
            return new DateTimeRangeCriterion<Message, DateTime>(c => c.CreateTime, start, end);
        }

        /// <summary>
        /// 已读
        /// </summary>
        /// <returns>返回已读条件</returns>
        public static Criterion<Message> Read()
        {
            return new DirectCriterion<Message>(c => c.ReadState == true);
        }

        /// <summary>
        /// 查看未读
        /// </summary>
        /// <returns>返回未读条件</returns>
        public static Criterion<Message> UnRead()
        {
            return new DirectCriterion<Message>(c => c.ReadState == false);
        }


        /// <summary>
        /// 查看已送达
        /// </summary>
        /// <returns>返回已送达条件</returns>
        public static Criterion<Message> Delivered(bool state)
        {
            return new DirectCriterion<Message>(c => c.DeliveryState == state);
        }

        /// <summary>
        /// 过期、未过期
        /// </summary>
        /// <returns>返回未过期条件</returns>
        public static Criterion<Message> Expired(bool state)
        {
            if (state)
                return new DirectCriterion<Message>(c => c.ExpirationTime < DateTime.Now);
            else
                return new DirectCriterion<Message>(c => c.ExpirationTime >= DateTime.Now);
        }

        /// <summary>
        /// 删除、未删除
        /// </summary>
        /// <returns>返回未删除条件</returns>
        public static Criterion<Message> Deleted(bool state)
        {
            if (state)
                return SoftDeleteCriteria.Deleted<Message>();
            else
                return SoftDeleteCriteria.NotDelete<Message>();
        }

        /// <summary>
        /// 消息展开成推送记录
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public static Criterion<Message> GenerateRecord(bool state)
        {
            return new DirectCriterion<Message>(c => c.GenerateRecord == state);
        }
    }
}
