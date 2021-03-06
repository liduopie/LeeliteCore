using System;
using System.Linq.Expressions;
using Leelite.Framework.Data.Query.Criteria;
using Leelite.Framework.Data.Query.Parameters;
using Leelite.Modules.FileStorage.Models.FileItemAgg;

namespace Leelite.Modules.FileStorage.Dtos.FileItemDtos
{
    public class FileItemQueryParameter : PageParameter<FileItem>
    {
        public override Expression<Func<FileItem, bool>> SatisfiedBy()
        {
            Criterion<FileItem> c = new TrueCriterion<FileItem>();

            return c.SatisfiedBy();
        }
    }
}

