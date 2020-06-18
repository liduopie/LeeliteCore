using System;
using System.Linq.Expressions;

namespace Leelite.Framework.Data.Query.Criteria
{
    /// <summary>
    /// 获取更多规约模式信息,
    /// 参见<see cref="http://martinfowler.com/apsupp/spec.pdf"/>
    /// 或者<see cref="http://en.wikipedia.org/wiki/Specification_pattern"/>
    /// 真正将Linq和lambda 表达式引入规约模式
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    public interface ICriterion<T>
    {
        /// <summary>
        /// 检查该规约是否符合lambda表达式的约束
        /// </summary>
        /// <returns>返回表达式</returns>
        Expression<Func<T, bool>> SatisfiedBy();
    }
}
