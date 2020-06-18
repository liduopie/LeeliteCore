using Leelite.Framework.Domain.Command;

namespace Leelite.Framework.Service.Commands
{
    public class DeleteCommand<TEntity, TKey> : Command<TKey, bool>
    {
        public DeleteCommand(TKey key) : base(key) { }
    }
}
