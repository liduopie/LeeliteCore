using System;
using System.Threading.Tasks;

namespace Leelite.Framework.Domain.Command
{
    public interface ICommandStore
    {
        /// <summary>
        /// Saves the command.
        /// </summary>
        /// <param name="command">Command.</param>
        void SaveCommand<TCommand>(TCommand command);

        /// <summary>
        /// Gets the events async.
        /// </summary>
        /// <returns>The events async.</returns>
        /// <param name="aggregateId">Aggregate identifier.</param>
        Task<TCommand> GetCommandAsync<TCommand>(Guid aggregateId);
    }
}
