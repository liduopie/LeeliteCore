using System.Collections.Generic;
using Leelite.Framework.Domain.Command;

namespace Leelite.Framework.Service.Commands
{
    public class BatchSaveCommand<TDto, TEntity, TKey> : Command<IList<TDto>>
    {

        public BatchSaveCommand(IList<TDto> addList, IList<TDto> updateList, IList<TDto> deleteList)
        {
            AddList = addList;
            UpdateList = updateList;
            DeleteList = deleteList;
        }

        public IList<TDto> AddList { get; }
        public IList<TDto> UpdateList { get; }
        public IList<TDto> DeleteList { get; }
    }
}
