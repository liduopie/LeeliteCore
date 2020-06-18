using System.Data.Common;

namespace Leelite.Extensions.EntityFramework.Connection
{
    public interface IConnectionFactory
    {
        DbConnection GetConnection(string connString);
    }
}
