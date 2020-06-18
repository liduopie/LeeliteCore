﻿using System;
using System.Linq.Expressions;
using Leelite.Framework.Data.Query.Criteria;
using Leelite.Framework.Data.Query.Parameters;
using Leelite.Modules.Settings.Models.SettingValueAgg;

namespace Leelite.Modules.Settings.Dtos.SettingValueDtos
{
    /// <summary>
    /// TenantId = 0,UserId = 0 时是应用配置
    /// </summary>
    public class SettingValueQueryParameter : PageParameter<SettingValue>
    {
        public long TenantId { get; set; }

        public long UserId { get; set; }

        public override Expression<Func<SettingValue, bool>> SatisfiedBy()
        {
            Criterion<SettingValue> c = new TrueCriterion<SettingValue>();

            c &= SettingValueCriteria.ByTenantId(TenantId);

            c &= SettingValueCriteria.ByUserId(UserId);

            return c.SatisfiedBy();
        }
    }
}
