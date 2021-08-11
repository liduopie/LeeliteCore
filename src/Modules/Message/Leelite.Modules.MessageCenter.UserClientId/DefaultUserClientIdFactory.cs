using Leelite.Modules.MessageCenter.UniPush;

using System;

namespace Leelite.Modules.MessageCenter.UserClientId
{
    public class DefaultUserClientIdFactory : IUserClientIdFactory
    {
        public string GetClientId(long userId)
        {
            return "8965a7a12229881df564850567328758";
        }
    }
}
