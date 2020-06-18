using Leelite.Framework.Domain.Command;

namespace Leelite.Framework.Service.Commands
{
    public class UpdateCommand<TCreateRequest, TDto, TEntity, TKey> : Command<TCreateRequest, TDto>
    {
        public UpdateCommand(TCreateRequest source) : base(source) { }
    }
}
