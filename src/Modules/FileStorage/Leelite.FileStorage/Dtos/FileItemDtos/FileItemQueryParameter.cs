using System;
using System.Linq.Expressions;
using Leelite.Framework.Data.Query.Criteria;
using Leelite.Framework.Data.Query.Parameters;
using Leelite.FileStorage.Models.FileItemAgg;
using Leelite.Framework.Data.Query.OrderBy;

namespace Leelite.FileStorage.Dtos.FileItemDtos
{
    public class FileItemQueryParameter : PageParameter<FileItem>
    {
        public FileItemQueryParameter()
        {
            SortItems.Add(new SortParam("Id"));
        }

        public override Expression<Func<FileItem, bool>> SatisfiedBy()
        {
            Criterion<FileItem> c = new TrueCriterion<FileItem>();

            return c.SatisfiedBy();
        }
    }
}

