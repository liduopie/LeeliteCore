using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

using Leelite.Framework.Domain.Context;

namespace Leelite.Framework.Domain.UnitOfWork
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly IsolationLevel _isolationLevel;
        private readonly IDictionary<DbConnection, IList<IContext>> _storage = new Dictionary<DbConnection, IList<IContext>>();

        private readonly IList<IDbContext> contexts = new List<IDbContext>();

        public EFUnitOfWork() : this(IsolationLevel.ReadCommitted) { }

        public EFUnitOfWork(IsolationLevel isolationLevel)
        {
            Id = Guid.NewGuid();
            _isolationLevel = isolationLevel;
        }

        /// <inheritdoc/>
        public Guid Id { get; }

        /// <inheritdoc/>
        public void Begin()
        {
            DbTransaction transaction = default;

            foreach (var item in contexts)
            {
                if (transaction == default)
                    transaction = item.BeginTransaction(_isolationLevel);
                else
                    item.UseTransaction(transaction);
            }
        }

        /// <inheritdoc/>
        public void Commit()
        {
            try
            {
                foreach (var item in contexts)
                {
                    item.CommitTransaction();
                }
            }
            catch (Exception ex)
            {

                foreach (var item in contexts)
                {
                    item.RollbackTransaction();
                }

                throw ex;
            }

        }

        public void Register(IDbContext context)
        {
            contexts.Add(context);
        }
    }
}
