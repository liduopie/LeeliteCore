using System;
using System.Linq.Expressions;
using Leelite.Framework.Data.Query.Criteria;
using Leelite.Framework.Data.Query.Parameters;
using Leelite.Modules.MessageCenter.Models.TemplateAgg.Models.TemplateAgg;

namespace Leelite.Modules.MessageCenter.Models.TemplateAgg.Dtos.TemplateDtos
{
    public class TemplateQueryParameter : PageParameter<Template>
    {
        public override Expression<Func<Template, bool>> SatisfiedBy()
        {
            Criterion<Template> c = new TrueCriterion<Template>();

            return c.SatisfiedBy();
        }
    }
}

