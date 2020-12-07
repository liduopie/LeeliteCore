using System.Collections.Generic;

namespace Leelite.Modules.IdentityServer.Admin.Api.Dtos.Clients
{
    public class ClientClaimsApiDto
    {
        public ClientClaimsApiDto()
        {
            ClientClaims = new List<ClientClaimApiDto>();
        }

        public List<ClientClaimApiDto> ClientClaims { get; set; }

        public int TotalCount { get; set; }

        public int PageSize { get; set; }
    }
}





