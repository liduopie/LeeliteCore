using Leelite.Framework.Data.Query.Criteria;
using Xunit;

namespace Leelite.Data.Query.Criteria
{
    public class DirectCriterion_UnitTest
    {
        /// <summary>
        /// 测试获取查询条件
        /// </summary>
        [Fact]
        public void SatisfiedBy_Test()
        {
            var criteria = new DirectCriterion<EntityOne>(c => c.Id == 1);
            Assert.Equal("c => (c.Id == 1)", criteria.SatisfiedBy().ToString());
        }
    }
}
