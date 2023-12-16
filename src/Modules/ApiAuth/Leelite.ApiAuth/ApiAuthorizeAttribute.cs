using AspNetCore.Authentication.ApiKey;

using Microsoft.AspNetCore.Authorization;

namespace Leelite.ApiAuth
{
    public class ApiAuthorizeAttribute : AuthorizeAttribute
    {
        public ApiAuthorizeAttribute() : base()
        {
            AuthenticationSchemes = ApiKeyDefaults.AuthenticationScheme;
        }
    }
}
