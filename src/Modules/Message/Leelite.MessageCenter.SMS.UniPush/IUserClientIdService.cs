using System;
using System.Collections.Generic;
using System.Text;

namespace Leelite.Modules.MessageCenter.UniPush
{
    public interface IUserClientIdService
    {
        public string GetClientID(long userId);
    }
}
