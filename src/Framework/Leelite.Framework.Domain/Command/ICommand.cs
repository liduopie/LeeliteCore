using System;
using MediatR;

namespace Leelite.Framework.Domain.Command
{
    public interface ICommand<TSource, TResult> : ICommand<TResult>
    {
        public TSource Source { get; set; }
    }

    public interface ICommand<TResult> : IRequest<TResult>
    {
        /// <summary>
        /// 事件Id
        /// </summary>
        Guid Id { get; set; }

        /// <summary>
        /// The time when the event occured.
        /// </summary>
        DateTime EventTime { get; set; }
    }
}
