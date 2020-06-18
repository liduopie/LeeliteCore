using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Leelite.Framework.Data.Store
{
    public abstract class EFAbstractStore<TEntity> : IAbstractStore<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// 初始化查询存储器
        /// </summary>
        /// <param name="dbcontext">工作单元</param>
        protected EFAbstractStore(DbContext dbcontext)
        {
            DbContext = dbcontext;
        }

        /// <summary>
        /// 工作单元
        /// </summary>
        protected DbContext DbContext { get; }

        /// <summary>
        /// 实体集
        /// </summary>
        protected DbSet<TEntity> DbSet
        {
            get
            {
                return DbContext.Set<TEntity>();
            }
        }

        /// <summary>
        /// 查询实体集合
        /// </summary>
        protected IQueryable<TEntity> Queryable { get; set; }

        /// <inheritdoc/>
        public void AsNoTracking()
        {
            Queryable = DbContext.Set<TEntity>().AsNoTracking();
        }

        /// <inheritdoc/>
        public IQueryable<TEntity> AsQueryable(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (Queryable == null)
                AsNoTracking();

            return Queryable;
        }

        /// <inheritdoc/>
        public void AsTracking()
        {
            Queryable = DbContext.Set<TEntity>();
        }
    }
}
