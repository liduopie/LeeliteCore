using System.Collections.Generic;
using System.Linq.Expressions;

namespace Leelite.Framework.Data.Query.Criteria
{
    /// <summary>
    /// 重新绑定参数助手，不在表达式中调用方法
    /// 该方法不支持所有Linq查询，例如在Linq2Entities。
    /// </summary>
    public sealed class ParameterRebinder : ExpressionVisitor
    {
        private readonly Dictionary<ParameterExpression, ParameterExpression> map;

        /// <summary>
        /// 默认构造函数
        /// </summary>
        /// <param name="map">映射规约</param>
        public ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
        {
            this.map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
        }

        /// <summary>
        /// 用映射信息替换参数表达式
        /// </summary>
        /// <param name="map">映射信息</param>
        /// <param name="exp">表达式替换参数</param>
        /// <returns>返回参数与表达式的替换结果</returns>
        public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
        {
            return new ParameterRebinder(map).Visit(exp);
        }

        /// <summary>
        /// 访问方法
        /// </summary>
        /// <param name="p">参数表达式</param>
        /// <returns>返回新的访问参数</returns>
        protected override Expression VisitParameter(ParameterExpression p)
        {
            ParameterExpression replacement;
            if (map.TryGetValue(p, out replacement))
            {
                p = replacement;
            }

            return base.VisitParameter(p);
        }

    }
}
