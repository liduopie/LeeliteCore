using System.Collections.Generic;
using Leelite.Framework.Domain.Model;

namespace Leelite.Domain.Model
{
    public class UserKey : ValueObject<UserKey>
    {
        public int No { get; set; }
        public string Code { get; set; }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            return new object[] { No, Code };
        }
    }
}
