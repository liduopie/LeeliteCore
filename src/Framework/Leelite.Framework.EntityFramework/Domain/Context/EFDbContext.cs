using System.Data;
using System.Data.Common;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Leelite.Framework.Domain.Context
{
    public class EFDbContext : DbContext, IDbContext
    {
        private readonly Guid _contextId = Guid.NewGuid();

        public Guid GetContextId()
        {
            return _contextId;
        }

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
            try
            {
                Database.RollbackTransaction();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void UseTransaction(DbTransaction transaction)
        {
            try
            {
                Database.UseTransaction(transaction);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
