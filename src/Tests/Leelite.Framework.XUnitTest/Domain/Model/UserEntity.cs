using Leelite.Framework.Domain.Model;

namespace Leelite.Domain.Model
{
    public class UserEntity : Entity<UserKey>
    {
        public UserEntity()
        {
            Id = new UserKey();
        }
    }
}
