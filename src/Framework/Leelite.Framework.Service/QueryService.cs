﻿using Leelite.Framework.Data.Query;
using Leelite.Framework.Data.Query.Paging;
using Leelite.Framework.Data.Query.Parameters;
using Leelite.Framework.Domain.Aggregate;
using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Domain.UnitOfWork;
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

        protected readonly IUnitOfWork _unitOfWork;

        public virtual IUnitOfWork UnitOfWork
        {
            get
            {
                return _unitOfWork;
            }
        }

        /// <summary>
        /// 查询存储器
        /// </summary>
        public IRepository<TEntity, TKey> Repository { get; set; }

        public QueryService(IRepository<TEntity, TKey> repository, IUnitOfWork unitOfWork, ILogger logger) : base(logger)
        {
            Repository = repository;
            _unitOfWork = unitOfWork;
        }


        /// <inheritdoc/>
        public virtual bool Exists(params TKey[] ids)
        {
            return Repository.Exists(ids);
        }

        /// <inheritdoc/>
        public virtual IList<TDto> Get(TQueryParameter parameter)
        {
            var query = new GenericQuery<TEntity, TQueryParameter>(parameter);

            return MapTo<IList<TDto>>(Repository.Find(query));
        }

        /// <inheritdoc/>
        public virtual async Task<IList<TDto>> GetAsync(TQueryParameter parameter)
        {
            var query = new GenericQuery<TEntity, TQueryParameter>(parameter);

            return MapTo<IList<TDto>>(await Repository.FindAsync(query));
        }

        /// <inheritdoc/>
        public virtual TDto GetById(TKey id)
        {
            var entity = Repository.FindById(id);

            return MapTo<TDto>(entity);
        }

        /// <inheritdoc/>
        public virtual async Task<TDto> GetByIdAsync(TKey id)
        {
            var entity = await Repository.FindByIdAsync(id);

            return MapTo<TDto>(entity);
        }

        /// <inheritdoc/>
        public virtual IList<TDto> GetByIds(IList<TKey> ids)
        {
            var entities = Repository.FindByIds(ids);

            return MapTo<IList<TDto>>(entities);
        }

        /// <inheritdoc/>
        public virtual async Task<IList<TDto>> GetByIdsAsync(IList<TKey> ids)
        {
            var entities = await Repository.FindByIdsAsync(ids);

            return MapTo<IList<TDto>>(entities);
        }

        /// <inheritdoc/>
        public virtual IList<TDto> GetPage(TQueryParameter parameter)
        {
            var query = new PagingQuery<TEntity, TQueryParameter>(parameter);

            return MapTo<IList<TDto>>(Repository.FindPage(query));
        }

        /// <inheritdoc/>
        public virtual PageList<TDto> GetPageList(TQueryParameter parameter)
        {
            var query = new PagingQuery<TEntity, TQueryParameter>(parameter);

            return MapTo<PageList<TDto>>(Repository.FindPageList(query));
        }

        /// <inheritdoc/>
        public virtual async Task<IList<TDto>> GetPageAsync(TQueryParameter parameter)
        {
            var query = new PagingQuery<TEntity, TQueryParameter>(parameter);

            return MapTo<IList<TDto>>(await Repository.FindPageAsync(query));
        }

        /// <inheritdoc/>
        public virtual async Task<PageList<TDto>> GetPageListAsync(TQueryParameter parameter)
        {
            var query = new PagingQuery<TEntity, TQueryParameter>(parameter);

            return MapTo<PageList<TDto>>(await Repository.FindPageListAsync(query));
        }
    }
}
