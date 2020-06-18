using System.Collections.Generic;
using Leelite.Framework.Domain.Command;

namespace Leelite.Framework.Service.Commands
{
    public class BatchDeleteCommand<TEntity, TKey> : Command<IEnumerable<TKey>, bool>
    {
        public BatchDeleteCommand(IEnumerable<TKey> ids) : base(ids) { }
    }
}
