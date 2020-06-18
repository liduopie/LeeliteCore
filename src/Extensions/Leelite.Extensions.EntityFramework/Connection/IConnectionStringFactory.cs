namespace Leelite.Extensions.EntityFramework.Connection
{
    public interface IConnectionStringFactory
    {
        string GetConnectionString(string name);
    }
}
