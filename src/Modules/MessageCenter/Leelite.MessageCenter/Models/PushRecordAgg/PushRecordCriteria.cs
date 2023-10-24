using System;
using System.Collections.Generic;
using System.Linq;

using Leelite.Framework.Data.Query.Criteria;

namespace Leelite.MessageCenter.Models.PushRecordAgg
{
    public static class PushRecordCriteria
    {
        /// <summary>
        /// 按照状态匹配
        /// </summary>
        /// <param name="states">状态集合</param>
        /// <returns></returns>
        public static Criterion<PushRecord> PushStates(PushState[] states)
        {
            return new DirectCriterion<PushRecord>(c => states.Contains(c.State));
        }

        /// <summary>
        /// 过期、未过期
        /// </summary>
        /// <returns></returns>
        public static Criterion<PushRecord> Expired(bool state)
        {
            if (state)
                return new DirectCriterion<PushRecord>(c => c.ExpirationTime < DateTime.Now);
            else
                return new DirectCriterion<PushRecord>(c => c.ExpirationTime >= DateTime.Now);
        }

        /// <summary>
        /// 备注字段中的 Topic
        /// </summary>
        /// <param name="topics"></param>
        /// <returns></returns>
        public static Criterion<PushRecord> Topics(IList<string> topics)
        {
            Criterion<PushRecord> criterions = new FalseCriterion<PushRecord>();

            foreach (var item in topics)
            {
                criterions |= new DirectCriterion<PushRecord>(c => c.Remark == item);
            }

            return criterions;
        }
    }
}
