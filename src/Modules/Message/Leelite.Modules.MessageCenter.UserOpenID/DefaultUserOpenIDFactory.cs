using Leelite.Modules.MessageCenter.Weixin;

using System;
using System.Collections.Generic;
using System.Text;

namespace Leelite.Modules.MessageCenter.UserOpenID
{
    public class DefaultUserOpenIDFactory : IUserOpenIDFactory
    {
        public string GetOpenId(string appId, long userId)
        {
            return "oY_Oo5GlUGQpplvowczGhxEZ1S3U";
        }
    }
}
