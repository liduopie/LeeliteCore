using System.Threading;
using System.Threading.Tasks;

namespace Leelite.Framework.Domain.Command
{
    /// <summary>
    /// Represents a bus for receiving commands.
    /// </summary>
    public interface ICommandBus
    {
        /// <summary>
        /// Sends command to the bus for execution.
        /// </summary>
        /// <param name="command">Command wrapped in an envelope.</param>
        /// <typeparam name="TCommand">Command type.</typeparam>
        Task<TResult> SendAsync<TResult>(ICommand<TResult> command, CancellationToken cancellationToken = default);
    }
}
