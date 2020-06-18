using Leelite.Framework.Service.Dtos;

namespace Leelite.Modules.Identity.Dtos.RoleDtos
{
    public class RoleDto : IDto<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string Description { get; set; }
    }
}
