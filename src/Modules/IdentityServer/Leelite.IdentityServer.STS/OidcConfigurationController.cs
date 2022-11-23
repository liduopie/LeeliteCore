using IdentityServer4.EntityFramework.Interfaces;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Leelite.Modules.IdentityServer.STS
{
    public class OidcConfigurationController : ControllerBase
    {
        private readonly ILogger<OidcConfigurationController> logger;

        public OidcConfigurationController(
            IClientRequestParametersProvider clientRequestParametersProvider,
            ILogger<OidcConfigurationController> _logger,
            IPersistedGrantDbContext context)
        {
            ClientRequestParametersProvider = clientRequestParametersProvider;
            logger = _logger;

            var list = context.PersistedGrants.ToList();
        }

        public IClientRequestParametersProvider ClientRequestParametersProvider { get; }

        [HttpGet("_configuration/{clientId}")]
        public IActionResult GetClientRequestParameters([FromRoute]string clientId)
        {
            var parameters = ClientRequestParametersProvider.GetClientParameters(HttpContext, clientId);
            return Ok(parameters);
        }
    }
}
