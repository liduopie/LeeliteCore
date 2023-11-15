using Leelite.Framework.Domain.Aggregate;

namespace Leelite.DataDictionary.Models.DataTypeAgg
{
    public class DataType : AggregateRoot<string>
    {
        public string Name { get; set; }

        /// <summary>
        /// 拥有者类别
        /// </summary>
        public OwnerType OwnerType { get; set; }
    }
}
