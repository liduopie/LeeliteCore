using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Leelite.Framework.Domain.Context
{
    public interface IDbContext : IContext
    {
        DbConnection GetConnection();

        /// <summary>
        /// Begins a new transaction.
        /// </summary>
        /// <param name="isolationLevel">Specifies the isolation level for the transaction.</param>
        /// <returns> The newly created transaction.</returns>
        DbTransaction BeginTransaction(IsolationLevel isolationLevel);

        /// <summary>
        /// Asynchronously begins a new transaction.
        /// </summary>
        /// <param name="isolationLevel">Specifies the isolation level for the transaction.</param>
        /// <param name="cancellationToken"> A System.Threading.CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the newly created transaction.</returns>
        Task<DbTransaction> BeginTransactionAsync(IsolationLevel isolationLevel, CancellationToken cancellationToken = default);

        /// <summary>
        ///  Sets the System.Data.Common.DbTransaction to be used by database operations on the ITransactionContext.
        /// </summary>
        /// <param name="transaction">The System.Data.Common.DbTransaction to use.</param>
        void UseTransaction(DbTransaction transaction);

        /// <summary>
        /// Commits all changes made to the database in the current transaction.
        /// </summary>
        void CommitTransaction();

        /// <summary>
        /// Discards all changes made to the database in the current transaction.
        /// </summary>
        void RollbackTransaction();
    }
}
