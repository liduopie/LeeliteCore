using Xunit;

namespace Leelite.Domain.Model
{
    public class ValueObject_UnitTest
    {
        [Fact]
        public void ValueObject_Equals_Test()
        {
            var value1 = new UserKey() { No = 1, Code = "A" };
            var value2 = new UserKey() { No = 1, Code = "A" };

            Assert.True(value1.Equals(value2));
        }

        [Fact]
        public void ValueObject_No_Equals_Test()
        {
            var valueA = new UserKey() { No = 1, Code = "A" };
            var valueB = new UserKey() { No = 2, Code = "B" };

            Assert.False(valueA.Equals(valueB));
        }

        [Fact]
        public void ValueObject_HashCode_Equals_Test()
        {
            var valueA = new UserKey() { No = 1, Code = "A" };
            var valueB = new UserKey() { No = 1, Code = "A" };

            var valueAHash = valueA.GetHashCode();
            var valueBHash = valueB.GetHashCode();

            Assert.True(valueAHash.Equals(valueBHash));
        }

        [Fact]
        public void ValueObject_HashCode_No_Equals_Test()
        {
            var valueA = new UserKey() { No = 1, Code = "A" };
            var valueB = new UserKey() { No = 2, Code = "B" };

            var valueAHash = valueA.GetHashCode();
            var valueBHash = valueB.GetHashCode();

            Assert.False(valueAHash.Equals(valueBHash));
        }
    }
}
