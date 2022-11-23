using System;
using System.Collections.Generic;
using System.Text;

namespace Leelite.Modules.MessageCenter.Weixin
{
    public interface IUserOpenIDFactory
    {
        public string GetOpenId(string appId, long userId);
    }
}
