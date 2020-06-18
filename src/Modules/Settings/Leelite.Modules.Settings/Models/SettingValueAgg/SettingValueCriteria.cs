using Leelite.Framework.Data.Query.Criteria;
using Microsoft.EntityFrameworkCore;

namespace Leelite.Modules.Settings.Models.SettingValueAgg
{
    public static class SettingValueCriteria
    {
        public static Criterion<SettingValue> ByTenantId(long? tenantId)
        {
            
            return new DirectCriterion<SettingValue>(c => EF.Property<long>(c, "_tenantId") == tenantId);
        }

        public static Criterion<SettingValue> ByUserId(long? userId)
        {
            return new DirectCriterion<SettingValue>(c => EF.Property<long>(c, "_userId") == userId);
        }
    }
}
