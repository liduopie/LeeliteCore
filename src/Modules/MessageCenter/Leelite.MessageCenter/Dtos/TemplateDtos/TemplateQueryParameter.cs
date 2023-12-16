using System;
using System.Linq.Expressions;
using Leelite.Framework.Data.Query.Criteria;
using Leelite.Framework.Data.Query.OrderBy;
using Leelite.Framework.Data.Query.Parameters;
using Leelite.MessageCenter.Models.TemplateAgg;

namespace Leelite.MessageCenter.Dtos.TemplateDtos
{
    public class TemplateQueryParameter : PageParameter<Template>
    {
        public TemplateQueryParameter()
        {
            SortItems.Add(new SortParam("Id"));
        }

        public override Expression<Func<Template, bool>> SatisfiedBy()
        {
            Criterion<Template> c = new TrueCriterion<Template>();

            return c.SatisfiedBy();
        }
    }
}

