using System;

namespace Leelite.Framework.Domain.UnitOfWork
{
    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class UnitOfWorkAttribute : Attribute
    {
    }
}
