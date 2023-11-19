using Leelite.Commons.Lifetime;
using Leelite.Framework.Data.Query.Parameters;
using Leelite.Framework.Domain.Aggregate;
using Leelite.Framework.Service.Dtos;
using Leelite.Framework.Service.Interfaces;

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
    public interface ICrudService<TEntity, TKey, TDto, TCreateRequest, TUpdateRequest, TQueryParameter> :
        IQueryService<TEntity, TKey, TDto, TQueryParameter>,
        IBatchSave<TDto>,
        IBatchSaveAsync<TDto>,
        ICreate<TCreateRequest, TDto>,
        ICreateAsync<TCreateRequest, TDto>,
        IDelete<TKey>,
        IDeleteAsync<TKey>,
        IUpdate<TKey, TUpdateRequest, TDto>,
        IUpdateAsync<TKey, TUpdateRequest, TDto>,
        IScope
        where TEntity : IAggregateRoot<TKey>
        where TKey : IEquatable<TKey>
        where TDto : IDto<TKey>
        where TCreateRequest : IRequest
        where TUpdateRequest : IUpdateRequest<TKey>
        where TQueryParameter : PageParameter<TEntity>
    {
    }
}
