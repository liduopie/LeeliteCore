using System;

namespace Leelite.Framework.Domain.Command
{
    public abstract class Command<TSource, TResult> : Command<TResult>, ICommand<TSource, TResult>
    {
        public Command(TSource source) : base()
        {
            Source = source;
        }

        public TSource Source { get; set; }
    }

    public abstract class Command<TResult> : ICommand<TResult>
    {
        public Command()
        {
            Id = Guid.NewGuid();
            EventTime = DateTime.Now;
        }

        public Guid Id { get; set; }

        public DateTime EventTime { get; set; }
    }
}
