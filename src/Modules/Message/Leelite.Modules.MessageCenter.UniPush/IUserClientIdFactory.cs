using System;
using System.Collections.Generic;
using System.Text;

namespace Leelite.Modules.MessageCenter.UniPush
{
    public interface IUserClientIdFactory
    {
        public string GetClientId(long userId);
    }
}
