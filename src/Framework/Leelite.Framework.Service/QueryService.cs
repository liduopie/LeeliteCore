using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Leelite.Framework.Data.Query;
using Leelite.Framework.Data.Query.Paging;
using Leelite.Framework.Data.Query.Parameters;
using Leelite.Framework.Domain.Aggregate;
using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Service.Dtos;
using Microsoft.Extensions.Logging;

namespace Leelite.Framework.Service
{

    /// <summary>
    /// 查询服务
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TKey">实体标识类型</typeparam>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQueryParameter">查询参数类型</typeparam>
    [ServiceAspects]
    public abstract class QueryService<TEntity, TKey, TDto, TQueryParameter> : AbstractService, IQueryService<TEntity, TKey, TDto, TQueryParameter>
        where TEntity : IAggregateRoot<TKey>
        where TKey : IEquatable<TKey>
        where TDto : IDto<TKey>
        where TQueryParameter : PageParameter<TEntity>
    {
        /// <summary>
        /// 查询存储器
        /// </summary>
        public IRepository<TEntity, TKey> Repository { get; set; }

        public QueryService(IRepository<TEntity, TKey> repository, ILogger logger) : base(logger)
        {
            Repository = repository;
        }


        /// <inheritdoc/>
        public bool Exists(params TKey[] ids)
        {
            return Repository.Exists(ids);
        }

        /// <inheritdoc/>
        public IList<TDto> Get(TQueryParameter parameter)
        {
            var query = new GenericQuery<TEntity, TQueryParameter>(parameter);

            return MapTo<IList<TDto>>(Repository.Find(query));
        }

        /// <inheritdoc/>
        public async Task<IList<TDto>> GetAsync(TQueryParameter parameter)
        {
            var query = new GenericQuery<TEntity, TQueryParameter>(parameter);

            return MapTo<IList<TDto>>(await Repository.FindAsync(query));
        }

        /// <inheritdoc/>
        public TDto GetById(TKey id)
        {
            var entity = Repository.FindById(id);

            return MapTo<TDto>(entity);
        }

        /// <inheritdoc/>
        public async Task<TDto> GetByIdAsync(TKey id)
        {
            var entity = await Repository.FindByIdAsync(id);

            return MapTo<TDto>(entity);
        }

        /// <inheritdoc/>
        public IList<TDto> GetByIds(IList<TKey> ids)
        {
            var entities = Repository.FindByIds(ids);

            return MapTo<IList<TDto>>(entities);
        }

        /// <inheritdoc/>
        public async Task<IList<TDto>> GetByIdsAsync(IList<TKey> ids)
        {
            var entities = await Repository.FindByIdsAsync(ids);

            return MapTo<IList<TDto>>(entities);
        }

        /// <inheritdoc/>
        public IList<TDto> GetPage(TQueryParameter parameter)
        {
            var query = new PagingQuery<TEntity, TQueryParameter>(parameter);

            return MapTo<IList<TDto>>(Repository.FindPage(query));
        }

        /// <inheritdoc/>
        public PageList<TDto> GetPageList(TQueryParameter parameter)
        {
            var query = new PagingQuery<TEntity, TQueryParameter>(parameter);

            return MapTo<PageList<TDto>>(Repository.FindPageList(query));
        }

        /// <inheritdoc/>
        public async Task<IList<TDto>> GetPageAsync(TQueryParameter parameter)
        {
            var query = new PagingQuery<TEntity, TQueryParameter>(parameter);

            return MapTo<IList<TDto>>(await Repository.FindPageAsync(query));
        }

        /// <inheritdoc/>
        public async Task<PageList<TDto>> GetPageListAsync(TQueryParameter parameter)
        {
            var query = new PagingQuery<TEntity, TQueryParameter>(parameter);

            return MapTo<PageList<TDto>>(await Repository.FindPageListAsync(query));
        }
    }
}
