using System.Reflection;

namespace Leelite.Commons.Convention
{
    /// <summary>
    /// 该接口负责注册程序集到指定的约定。
    /// </summary>
    /// <remarks>
    /// 实现该接口并通过 <see cref="ConventionManager.AddRegistrar"/> 方法注册自己的约定。
    /// </remarks>
    public interface IConventionRegistrar
    {
        /// <summary>
        /// 按照约定注册程序集。
        /// </summary>
        /// <param name="assembly">注册程序集</param>
        void RegisterAssembly(Assembly assembly);
    }
}