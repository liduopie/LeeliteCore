using AspNetCore.Authentication.ApiKey;

using Microsoft.AspNetCore.Authorization;

namespace Leelite.AspNetCore
{
    public class ApiKeyAuthorizeAttribute : AuthorizeAttribute
    {
        public ApiKeyAuthorizeAttribute() : base()
        {
            AuthenticationSchemes = ApiKeyDefaults.AuthenticationScheme;
        }
    }
}
