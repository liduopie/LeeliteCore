using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Leelite.Framework.Data.Query.Paging;
using Leelite.Framework.Data.Query.Parameters;
using Microsoft.EntityFrameworkCore;

namespace Leelite.Framework.Data.Query
{
    public static class QueryExtensions
    {
        public static async Task<IList<TEntity>> QueryAsync<TEntity, TQueryParameter>(this IGenericQuery<TEntity, TQueryParameter> query, IQueryable<TEntity> source, CancellationToken cancellationToken = default)
            where TQueryParameter : GenericParameter<TEntity>
        {
            return await query.BuildQueryable(source).ToListAsync(cancellationToken);
        }

        public static async Task<IList<TEntity>> PageQueryAsync<TEntity, TQueryParameter>(this IPagingQuery<TEntity, TQueryParameter> query, IQueryable<TEntity> source, CancellationToken cancellationToken = default)
            where TQueryParameter : PageParameter<TEntity>
        {
            return await query.BuildPageQueryable(source).ToListAsync(cancellationToken);
        }

        public static async Task<PageList<TEntity>> PageListQueryAsync<TEntity, TQueryParameter>(this IPagingQuery<TEntity, TQueryParameter> query, IQueryable<TEntity> source, CancellationToken cancellationToken = default)
            where TQueryParameter : PageParameter<TEntity>
        {
            var totalCount = await query.BuildQueryable(source).CountAsync(cancellationToken);

            var pageList = await query.BuildPageQueryable(source).ToListAsync(cancellationToken);

            return new PageList<TEntity>(pageList, query.Parameter.Pager, query.Parameter.SortItems, totalCount);
        }
    }
}
