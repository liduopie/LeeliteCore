using System;

namespace Leelite.Commons.Lifetime
{
    public interface IOperation
    {
        Guid OperationId { get; }
    }

    public interface IOperationTransient : IOperation, ITransient
    {
    }

    public interface IOperationScoped : IOperation, IScope
    {
    }

    public interface IOperationSingleton : IOperation, ISingleton
    {
    }

    public class OperationTransient : IOperationTransient
    {
        public OperationTransient() : this(Guid.NewGuid())
        {
        }

        public OperationTransient(Guid id)
        {
            OperationId = id;
        }

        public Guid OperationId { get; private set; }
    }

    public class OperationScoped : IOperationScoped
    {
        public OperationScoped() : this(Guid.NewGuid())
        {
        }

        public OperationScoped(Guid id)
        {
            OperationId = id;
        }

        public Guid OperationId { get; private set; }
    }

    public class OperationSingleton : IOperationSingleton
    {
        public OperationSingleton() : this(Guid.NewGuid())
        {
        }

        public OperationSingleton(Guid id)
        {
            OperationId = id;
        }

        public Guid OperationId { get; private set; }
    }
}
