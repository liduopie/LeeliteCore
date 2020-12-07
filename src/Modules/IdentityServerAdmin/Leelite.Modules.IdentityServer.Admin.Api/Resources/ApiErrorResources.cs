using Leelite.Modules.IdentityServer.Admin.Api.ExceptionHandling;

namespace Leelite.Modules.IdentityServer.Admin.Api.Resources
{
    public class ApiErrorResources : IApiErrorResources
    {
        public virtual ApiError CannotSetId()
        {
            return new ApiError
            {
                Code = nameof(CannotSetId),
                Description = ApiErrorResource.CannotSetId
            };
        }
    }
}





