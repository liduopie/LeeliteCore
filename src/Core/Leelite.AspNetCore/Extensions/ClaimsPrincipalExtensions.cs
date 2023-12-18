using System.Security.Claims;

using Leelite.Commons.Host;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Leelite.AspNetCore.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static long GetUserId(this ClaimsPrincipal claims)
        {
            return GetUserId<long>(claims);
        }

        public static T GetUserId<T>(this ClaimsPrincipal claims)
        {

            var options = HostManager.WebApplication.Services.GetService<IOptionsMonitor<IdentityOptions>>().CurrentValue;

            var id = claims.FindFirstValue(options.ClaimsIdentity.UserIdClaimType);

            return Commons.Helpers.Convert.To<T>(id);
        }

    }
}
