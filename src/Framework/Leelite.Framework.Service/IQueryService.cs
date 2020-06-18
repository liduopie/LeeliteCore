using System;
using Leelite.Framework.Data.Query.Parameters;
using Leelite.Framework.Domain.Aggregate;
using Leelite.Framework.Service.Dtos;
using Leelite.Framework.Service.Interfaces;

namespace Leelite.Framework.Service
{
    /// <summary>
    /// 查询服务
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TKey">实体标识类型</typeparam>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQueryParameter">查询参数类型</typeparam>
    public interface IQueryService<TEntity, TKey, TDto, TQueryParameter> :
        IService<TEntity, TKey>,
        IExists<TKey>,
        IGet<TEntity, TDto, TQueryParameter>,
        IGetAsync<TEntity, TDto, TQueryParameter>,
        IGetById<TDto, TKey>,
        IGetByIdAsync<TDto, TKey>,
        IGetPaging<TEntity, TDto, TQueryParameter>,
        IGetPagingAsync<TEntity, TDto, TQueryParameter>
        where TEntity : IAggregateRoot<TKey>
        where TKey : IEquatable<TKey>
        where TDto : IDto<TKey>
        where TQueryParameter : PageParameter<TEntity>
    {
    }
}
