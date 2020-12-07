using System;
using System.Collections.Generic;
using System.Text;
using Leelite.Commons.Host;
using Leelite.Core.Module;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Leelite.Modules.IdentityServer.Admin.UI
{
    public class IdentityServerAdminUIModule : ModuleBase
    {
        public override void ConfigureServices(HostContext context)
        {
            var services = context.ServiceDescriptors;
        }
    }
}
