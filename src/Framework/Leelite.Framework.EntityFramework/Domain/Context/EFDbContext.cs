using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Leelite.Framework.Domain.Context
{
    public class EFDbContext : DbContext, IDbContext
    {
        public EFDbContext(DbContextOptions options) : base(options) { }

        public DbConnection GetConnection()
        {
            return Database.GetDbConnection();
        }

        public DbTransaction BeginTransaction(IsolationLevel isolationLevel)
        {
            return Database.BeginTransaction(isolationLevel).GetDbTransaction();
        }

        public async Task<DbTransaction> BeginTransactionAsync(IsolationLevel isolationLevel, CancellationToken cancellationToken = default)
        {
            var transaction = await Database.BeginTransactionAsync(isolationLevel, cancellationToken);

            return transaction.GetDbTransaction();
        }

        public void CommitTransaction()
        {
            Database.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            Database.RollbackTransaction();
        }

        public void UseTransaction(DbTransaction transaction)
        {
            Database.UseTransaction(transaction);
        }
    }
}
