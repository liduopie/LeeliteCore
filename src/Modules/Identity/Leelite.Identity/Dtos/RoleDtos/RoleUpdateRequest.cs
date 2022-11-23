using Leelite.Framework.Service.Dtos;

namespace Leelite.Identity.Dtos.RoleDtos
{
    public class RoleUpdateRequest : IUpdateRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ConcurrencyStamp { get; set; }
    }
}
