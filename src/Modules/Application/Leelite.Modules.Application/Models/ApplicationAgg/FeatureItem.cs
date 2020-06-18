using System.Collections.Generic;
using Leelite.Framework.Domain.Model;

namespace Leelite.Modules.Application.Models.ApplicationAgg
{
    public class FeatureItem : ValueObject<FeatureItem>
    {
        /// <summary>
        /// 应用代码
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 功能代码
        /// </summary>
        public string FeatureCode { get; set; }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            return new object[] { AppId, FeatureCode };
        }
    }
}
