using Leelite.Framework.Service.Dtos;

namespace Leelite.Identity.Dtos.RoleDtos
{
    public class RoleCreateRequest : IRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
