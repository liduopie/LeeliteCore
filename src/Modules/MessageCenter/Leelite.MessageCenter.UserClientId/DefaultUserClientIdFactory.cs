using Leelite.MessageCenter.UniPush;

namespace Leelite.MessageCenter.UserClientId
{
    public class DefaultUserClientIdFactory : IUserClientIdFactory
    {
        public string GetClientId(long userId)
        {
            return "8965a7a12229881df5648502";
        }
    }
}
