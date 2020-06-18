using System;
using Leelite.Framework.Domain.Command;

namespace Leelite.Framework.Service.Commands
{
    public class CreateCommand<TCreateRequest, TDto, TEntity, TKey> : Command<TCreateRequest, TDto>
    {
        public CreateCommand(TCreateRequest source) : base(source) { }
    }
}
