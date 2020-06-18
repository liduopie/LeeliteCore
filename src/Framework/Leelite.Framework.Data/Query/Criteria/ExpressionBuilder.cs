using System;
using System.Linq;
using System.Linq.Expressions;

namespace Leelite.Framework.Data.Query.Criteria
{
    /// <summary>
    /// 并、或运算，将参数重新绑定的扩展方法
    /// </summary>
    public static class ExpressionBuilder
    {
        /// <summary>
        /// 组合两个表达式合并成一个新的表达式
        /// </summary>
        /// <typeparam name="T">表达式参数类型</typeparam>
        /// <param name="first">表达式实例</param>
        /// <param name="second">合并表达式</param>
        /// <param name="merge">合并方法</param>
        /// <returns>返回组合表达式</returns>
        public static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
        {
            // 创建参数映射,从second到first
            var map = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] }).ToDictionary(p => p.s, p => p.f);

            // second合并first后的结果
            var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);

            // 将表达式应用到first并返回
            return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
        }
        /// <summary>
        /// 并运算
        /// </summary>
        /// <typeparam name="T">表达式参数类型</typeparam>
        /// <param name="first">并运算右表达式</param>
        /// <param name="second">并运算左表达式</param>
        /// <returns>返回并运算后的表达式</returns>
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.And);
        }
        /// <summary>
        /// 或运算
        /// </summary>
        /// <typeparam name="T">表达式参数类型</typeparam>
        /// <param name="first">或运算右表达式</param>
        /// <param name="second">或运算左表达式</param>
        /// <returns>返回或运算后的表达式</returns>
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.Or);
        }

    }
}
