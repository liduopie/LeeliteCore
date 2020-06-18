using MediatR;

namespace Leelite.Framework.Domain.Command
{
    public interface ICommandHandler<TCommand, TResult> : IRequestHandler<TCommand, TResult>
         where TCommand : IRequest<TResult>
    {
    }
}
