using System;
using Xunit;

namespace Leelite.Domain.Model
{
    public class IEntity_UnitTest
    {
        [Fact]
        public void Multi_Type_Entity_Test()
        {
            var intEntity = new IntEntity() { Id = 1 };
            var longEntity = new LongEntity() { Id = 1 };
            var stringEntity = new StringEntity() { Id = "A" };
            var guidEntity = new GuidEntity() { Id = new Guid() };
            var userEntity = new UserEntity() { Id = { No = 1, Code = "AA" } };

            Assert.NotNull(intEntity);
            Assert.NotNull(longEntity);
            Assert.NotNull(stringEntity);
            Assert.NotNull(guidEntity);
            Assert.NotNull(userEntity);

        }

        [Fact]
        public void Entity_IsTransient_Test()
        {
            var intEntity = new IntEntity();

            Assert.True(intEntity.IsTransient());

            var longEntity = new LongEntity();

            Assert.True(longEntity.IsTransient());

            var stringEntity = new StringEntity();

            Assert.True(stringEntity.IsTransient());

            var guidEntity = new GuidEntity();

            Assert.True(guidEntity.IsTransient());

            var userEntity = new UserEntity();

            Assert.True(userEntity.IsTransient());

        }


        [Fact]
        public void Entity_Equals_Test()
        {
            var userEntity1 = new UserEntity() { Id = { No = 1, Code = "AA" } };
            var userEntity2 = new UserEntity() { Id = { No = 1, Code = "AA" } };

            Assert.True(userEntity1.Equals(userEntity2));
        }

        [Fact]
        public void Entity_No_Equals_Test()
        {
            var intEntity = new IntEntity() { Id = 1 };
            var longEntity = new LongEntity() { Id = 1 };

            Assert.False(intEntity.Equals(longEntity));


            var guidEntity1 = new GuidEntity();
            var guidEntity2 = new GuidEntity();

            Assert.False(guidEntity1.Equals(guidEntity2));
        }
    }
}
