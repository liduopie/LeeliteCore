using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Leelite.Core.Validation;
using Leelite.Framework.Data.Query.Parameters;
using Leelite.Framework.Domain.Aggregate;
using Leelite.Framework.Domain.Command;
using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Domain.UnitOfWork;
using Leelite.Framework.Service.Commands;
using Leelite.Framework.Service.Dtos;

using Microsoft.Extensions.Logging;

namespace Leelite.Framework.Service
{
    /// <summary>
    /// 服务
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TKey">实体标识类型</typeparam>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TCreateRequest">创建参数类型</typeparam>
    /// <typeparam name="TUpdateRequest">修改参数类型</typeparam>
    /// <typeparam name="TQueryParameter">查询参数类型</typeparam>
    [ServiceAspects]
    public class CrudService<TEntity, TKey, TDto, TCreateRequest, TUpdateRequest, TQueryParameter> : QueryService<TEntity, TKey, TDto, TQueryParameter>,
        ICrudService<TEntity, TKey, TDto, TCreateRequest, TUpdateRequest, TQueryParameter>
        where TEntity : IAggregateRoot<TKey>
        where TKey : IEquatable<TKey>
        where TDto : IDto<TKey>
        where TCreateRequest : IRequest
        where TUpdateRequest : IUpdateRequest<TKey>
        where TQueryParameter : PageParameter<TEntity>
    {
        protected readonly ICommandBus _commandBus;

        public CrudService(
            IRepository<TEntity, TKey> repository,
            ICommandBus commandBus,
            ILogger logger
            ) : base(repository, logger)
        {
            _commandBus = commandBus;
        }

        /// <inheritdoc/>
        [UnitOfWork]
        public virtual TDto Create([Valid] TCreateRequest request)
        {
            return _commandBus.SendAsync(new CreateCommand<TCreateRequest, TDto, TEntity, TKey>(request)).Result;
        }

        /// <inheritdoc/>
        [UnitOfWork]
        public virtual async Task<TDto> CreateAsync([Valid] TCreateRequest request)
        {
            return await _commandBus.SendAsync(new CreateCommand<TCreateRequest, TDto, TEntity, TKey>(request));
        }

        /// <inheritdoc/>
        [UnitOfWork]
        public virtual void Delete(TKey id)
        {
            _commandBus.SendAsync(new DeleteCommand<TEntity, TKey>(id)).Wait();
        }

        /// <inheritdoc/>
        public virtual void Delete(TKey[] ids)
        {
            _commandBus.SendAsync(new BatchDeleteCommand<TEntity, TKey>(ids)).Wait();
        }

        /// <inheritdoc/>
        public virtual async Task DeleteAsync(TKey[] ids)
        {
            await _commandBus.SendAsync(new BatchDeleteCommand<TEntity, TKey>(ids));
        }

        /// <inheritdoc/>
        [UnitOfWork]
        public virtual async Task DeleteAsync(TKey id)
        {
            await _commandBus.SendAsync(new DeleteCommand<TEntity, TKey>(id));
        }

        /// <inheritdoc/>
        [UnitOfWork]
        public virtual IList<TDto> Save(IList<TDto> addList, IList<TDto> updateList, IList<TDto> deleteList)
        {
            return _commandBus.SendAsync(new BatchSaveCommand<TDto, TEntity, TKey>(addList, updateList, deleteList)).Result;
        }

        /// <inheritdoc/>
        [UnitOfWork]
        public virtual async Task<IList<TDto>> SaveAsync(IList<TDto> addList, IList<TDto> updateList, IList<TDto> deleteList)
        {
            return await _commandBus.SendAsync(new BatchSaveCommand<TDto, TEntity, TKey>(addList, updateList, deleteList));
        }

        /// <inheritdoc/>
        [UnitOfWork]
        public virtual TDto Update([Valid] TUpdateRequest request)
        {
            return _commandBus.SendAsync(new UpdateCommand<TUpdateRequest, TDto, TEntity, TKey>(request)).Result;
        }

        /// <inheritdoc/>
        [UnitOfWork]
        public virtual async Task<TDto> UpdateAsync([Valid] TUpdateRequest request)
        {
            return await _commandBus.SendAsync(new UpdateCommand<TUpdateRequest, TDto, TEntity, TKey>(request));
        }
    }
}
