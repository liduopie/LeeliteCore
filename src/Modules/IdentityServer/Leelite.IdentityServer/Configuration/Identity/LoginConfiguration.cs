using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leelite.Modules.IdentityServer.Configuration.Identity
{
    public class LoginConfiguration
    {
        public LoginResolutionPolicy ResolutionPolicy { get; set; } = LoginResolutionPolicy.Username;
    }
}
