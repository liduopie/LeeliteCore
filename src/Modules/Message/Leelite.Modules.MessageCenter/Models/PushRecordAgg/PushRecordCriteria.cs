using Leelite.Framework.Data.Query.Criteria;

using System;
using System.Linq;

namespace Leelite.Modules.MessageCenter.Models.PushRecordAgg
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
    }
}
