using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Leelite.Framework.Domain.Command
{
    public class CommandBus : ICommandBus
    {
        private readonly IMediator _mediator;

        public CommandBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<TResult> SendAsync<TResult>(ICommand<TResult> command, CancellationToken cancellationToken = default)
        {
            return _mediator.Send(command, cancellationToken);
        }
    }
}
