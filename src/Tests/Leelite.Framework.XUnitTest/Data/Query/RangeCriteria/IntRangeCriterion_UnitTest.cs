using Leelite.Framework.Data.Query.RangeCriteria;
using Xunit;

namespace Leelite.Data.Query.RangeCriteria
{
    /// <summary>
    /// 测试整数范围过滤条件
    /// </summary>
    public class IntRangeCriterion_UnitTest
    {
        /// <summary>
        /// 测试获取查询条件
        /// </summary>
        [Fact]
        public void SatisfiedBy_Test()
        {
            IntRangeCriterion<EntityOne, int> criteria = new IntRangeCriterion<EntityOne, int>(t => t.Id, 1, 10);
            Assert.Equal("t => ((t.Id >= 1) AndAlso (t.Id <= 10))", criteria.SatisfiedBy().ToString());

            IntRangeCriterion<EntityOne, int?> criteria2 = new IntRangeCriterion<EntityOne, int?>(t => t.Age, 1, 10);
            Assert.Equal("t => ((t.Age >= 1) AndAlso (t.Age <= 10))", criteria2.SatisfiedBy().ToString());
        }

        /// <summary>
        /// 测试获取查询条件 - 设置边界
        /// </summary>
        [Fact]
        public void SatisfiedBy_Boundary_Test()
        {
            IntRangeCriterion<EntityOne, int> criteria = new IntRangeCriterion<EntityOne, int>(t => t.Tel, 1, 10, Boundary.Neither);
            Assert.Equal("t => ((t.Tel > 1) AndAlso (t.Tel < 10))", criteria.SatisfiedBy().ToString());

            criteria = new IntRangeCriterion<EntityOne, int>(t => t.Tel, 1, 10, Boundary.Left);
            Assert.Equal("t => ((t.Tel >= 1) AndAlso (t.Tel < 10))", criteria.SatisfiedBy().ToString());

            IntRangeCriterion<EntityOne, int?> criteria2 = new IntRangeCriterion<EntityOne, int?>(t => t.Age, 1, 10, Boundary.Right);
            Assert.Equal("t => ((t.Age > 1) AndAlso (t.Age <= 10))", criteria2.SatisfiedBy().ToString());

            criteria2 = new IntRangeCriterion<EntityOne, int?>(t => t.Age, 1, 10, Boundary.Both);
            Assert.Equal("t => ((t.Age >= 1) AndAlso (t.Age <= 10))", criteria2.SatisfiedBy().ToString());
        }

        /// <summary>
        /// 测试获取查询条件 - 最小值大于最大值，则交换大小值的位置
        /// </summary>
        [Fact]
        public void SatisfiedBy_MinGreaterMax_Test()
        {
            IntRangeCriterion<EntityOne, int> criteria = new IntRangeCriterion<EntityOne, int>(t => t.Tel, 10, 1);
            Assert.Equal("t => ((t.Tel >= 1) AndAlso (t.Tel <= 10))", criteria.SatisfiedBy().ToString());

            IntRangeCriterion<EntityOne, int?> criteria2 = new IntRangeCriterion<EntityOne, int?>(t => t.Age, 10, 1);
            Assert.Equal("t => ((t.Age >= 1) AndAlso (t.Age <= 10))", criteria2.SatisfiedBy().ToString());
        }

        /// <summary>
        /// 测试获取查询条件 - 最小值为空，忽略最小值条件
        /// </summary>
        [Fact]
        public void SatisfiedBy_MinIsNull_Test()
        {
            IntRangeCriterion<EntityOne, int> criteria = new IntRangeCriterion<EntityOne, int>(t => t.Tel, null, 10);
            Assert.Equal("t => (t.Tel <= 10)", criteria.SatisfiedBy().ToString());

            IntRangeCriterion<EntityOne, int?> criteria2 = new IntRangeCriterion<EntityOne, int?>(t => t.Age, null, 10);
            Assert.Equal("t => (t.Age <= 10)", criteria2.SatisfiedBy().ToString());
        }

        /// <summary>
        /// 测试获取查询条件 - 最大值为空，忽略最大值条件
        /// </summary>
        [Fact]
        public void SatisfiedBy_MaxIsNull_Test()
        {
            IntRangeCriterion<EntityOne, int> criteria = new IntRangeCriterion<EntityOne, int>(t => t.Tel, 1, null);
            Assert.Equal("t => (t.Tel >= 1)", criteria.SatisfiedBy().ToString());

            IntRangeCriterion<EntityOne, int?> criteria2 = new IntRangeCriterion<EntityOne, int?>(t => t.Age, 1, null);
            Assert.Equal("t => (t.Age >= 1)", criteria2.SatisfiedBy().ToString());
        }

        /// <summary>
        /// 测试获取查询条件 - 最大值和最小值均为null,忽略所有条件
        /// </summary>
        [Fact]
        public void BothNull_Test()
        {
            IntRangeCriterion<EntityOne, int> criteria = new IntRangeCriterion<EntityOne, int>(t => t.Tel, null, null);
            Assert.Null(criteria.SatisfiedBy());

            IntRangeCriterion<EntityOne, int?> criteria2 = new IntRangeCriterion<EntityOne, int?>(t => t.Age, null, null);
            Assert.Null(criteria2.SatisfiedBy());
        }
    }
}
