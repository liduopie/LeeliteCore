using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Leelite.Framework.Data.Query.Criteria;
using Leelite.Framework.Data.Query.OrderBy;
using Leelite.Framework.Data.Query.Parameters;

namespace Leelite.Framework.Data.Query
{
    /// <summary>
    /// 一般条件查询对象
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <typeparam name="TQueryParameter">查询参数</typeparam>
    public class GenericQuery<T, TQueryParameter> : IGenericQuery<T, TQueryParameter>
        where TQueryParameter : GenericParameter<T>
    {
        private Criterion<T> parameterCriterion;

        public TQueryParameter Parameter { get; set; }


        public GenericQuery(TQueryParameter parameter)
        {
            Parameter = parameter;
            parameterCriterion = Parameter;
        }

        /// <inheritdoc/>
        public virtual IQueryable<T> BuildQueryable(IQueryable<T> source)
        {
            return source
               .Where(parameterCriterion.SatisfiedBy())
               .OrderBy(Parameter.SortItems);
        }

        /// <inheritdoc/>
        public virtual IList<T> Query(IQueryable<T> source)
        {
            return BuildQueryable(source).ToList();
        }

        /// <inheritdoc/>
        public IQuery<T> Where(Criterion<T> criterion)
        {
            parameterCriterion &= criterion;

            return this;
        }

        /// <inheritdoc/>
        public IQuery<T> Where(Expression<Func<T, bool>> predicate)
        {
            parameterCriterion &= new DirectCriterion<T>(predicate);

            return this;
        }

        /// <inheritdoc/>
        public IQuery<T> OrderBy(string filedName, bool desc = false)
        {
            Parameter.SortItems.Add(new SortParam(filedName, desc));

            return this;
        }

        /// <inheritdoc/>
        public IQuery<T> OrderBy(SortParam param)
        {
            Parameter.SortItems.Add(param);

            return this;
        }

    }
}
