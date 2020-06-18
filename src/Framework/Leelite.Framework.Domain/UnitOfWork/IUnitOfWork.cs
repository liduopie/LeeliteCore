using System;
using Leelite.Framework.Domain.Context;

namespace Leelite.Framework.Domain.UnitOfWork
{
    /// <summary>
    /// 工作单元
    /// </summary>
    public interface IUnitOfWork
    {
        Guid Id { get; }

        /// <summary>
        /// 创建工作单元
        /// </summary>
        void Begin();

        /// <summary>
        /// 提交工作单元
        /// </summary>
        void Commit();

        /// <summary>
        /// 注册上下文到工作单元
        /// </summary>
        /// <param name="context">上下文</param>
        void Register(IDbContext context);
    }
}
