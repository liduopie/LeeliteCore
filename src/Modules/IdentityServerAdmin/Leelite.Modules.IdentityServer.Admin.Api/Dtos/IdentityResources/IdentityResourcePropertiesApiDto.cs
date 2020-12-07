using System.Collections.Generic;

namespace Leelite.Modules.IdentityServer.Admin.Api.Dtos.IdentityResources
{
    public class IdentityResourcePropertiesApiDto
    {
        public IdentityResourcePropertiesApiDto()
        {
            IdentityResourceProperties = new List<IdentityResourcePropertyApiDto>();
        }

        public int TotalCount { get; set; }

        public int PageSize { get; set; }

        public List<IdentityResourcePropertyApiDto> IdentityResourceProperties { get; set; }
    }
}





