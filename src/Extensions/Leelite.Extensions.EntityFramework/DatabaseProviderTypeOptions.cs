namespace Leelite.Extensions.EntityFramework
{
    public class DatabaseProviderTypeOptions : IProviderTypeOptions
    {
        public DatabaseProviderType ProviderType { get; set; } = DatabaseProviderType.Npgsql;
    }
}
