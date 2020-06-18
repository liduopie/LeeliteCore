using System.Collections.Generic;

namespace Leelite.Modules.IdentityServer.Admin.Api.Dtos.ApiResources
{
    public class ApiSecretsApiDto
    {
        public ApiSecretsApiDto()
        {
            ApiSecrets = new List<ApiSecretApiDto>();
        }

        public int TotalCount { get; set; }

        public int PageSize { get; set; }

        public List<ApiSecretApiDto> ApiSecrets { get; set; }
    }
}





