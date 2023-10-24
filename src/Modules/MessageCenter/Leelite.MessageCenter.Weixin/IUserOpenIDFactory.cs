using System;
using System.Collections.Generic;
using System.Text;

namespace Leelite.MessageCenter.Weixin
{
    public interface IUserOpenIDFactory
    {
        public string GetOpenId(string appId, long userId);
    }
}
