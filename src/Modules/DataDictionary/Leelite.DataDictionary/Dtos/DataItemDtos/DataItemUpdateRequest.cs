using Leelite.Framework.Service.Dtos;

namespace Leelite.DataDictionary.Dtos.DataItemDtos
{
    public class DataItemUpdateRequest : IUpdateRequest<int>
    {
        public int Id { get; set; }

        public string DataTypeId { get; set; }

        public long OrganizationId { get; set; }

        public string Code { get; set; }

        public string Value { get; set; }

        public int Sort { get; set; }

        public bool Enabled { get; set; }

    }
}
