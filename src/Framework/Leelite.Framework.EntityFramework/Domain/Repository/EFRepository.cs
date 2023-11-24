using Leelite.Framework.Data.Store;
using Leelite.Framework.Domain.Aggregate;
using Leelite.Framework.Domain.Context;
using Leelite.Framework.Domain.UnitOfWork;

using Microsoft.EntityFrameworkCore;

namespace Leelite.Framework.Domain.Repository
{
    /// <summary>
    /// 仓储
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TKey">实体标识类型</typeparam>
    public abstract class EFRepository<TEntity, TKey> : EFStore<TEntity>, IRepository<TEntity, TKey>
        where TEntity : class, IAggregateRoot<TKey>
        where TKey : IEquatable<TKey>
    {
        public EFRepository(DbContext dbContext, IUnitOfWork unitOfWork) : base(dbContext)
        {
            unitOfWork.Register((IDbContext)dbContext);
        }

        /// <inheritdoc/>
        public TEntity FindById(TKey id)
        {
            var result = Find(c => c.Id.Equals(id));

            if (result.Count > 0)
                return result[0];
            else
                return default;
        }

        /// <inheritdoc/>
        public async Task<TEntity> FindByIdAsync(TKey id, CancellationToken cancellationToken = default)
        {
            var result = await FindAsync(c => c.Id.Equals(id), cancellationToken);

            if (result.Count > 0)
                return result[0];
            else
                return default;
        }
    }
}
