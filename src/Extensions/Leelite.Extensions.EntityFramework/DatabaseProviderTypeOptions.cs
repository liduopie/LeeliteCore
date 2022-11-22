namespace Leelite.Extensions.EntityFramework
{
    public class DatabaseProviderTypeOptions : IProviderTypeOptions
    {
        public DatabaseProviderType ConnectionProviderType { get; set; } = DatabaseProviderType.Npgsql;
    }
}
