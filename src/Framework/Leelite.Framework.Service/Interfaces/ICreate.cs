using Leelite.Framework.Service.Dtos;

namespace Leelite.Framework.Service.Interfaces
{
    /// <summary>
    /// 创建操作
    /// </summary>
    /// <typeparam name="TCreateRequest">创建参数类型</typeparam>
    public interface ICreate<TCreateRequest, TDto> where TCreateRequest : IRequest
    {
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="request">创建参数</param>
        TDto Create(TCreateRequest request);
    }
}
