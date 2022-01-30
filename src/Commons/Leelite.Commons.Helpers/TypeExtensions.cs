using System.Diagnostics.CodeAnalysis;

namespace System
{
    public static class TypeExtensions
    {
        /// <summary>
        /// 判断指定的类型 <paramref name="type"/> 是否是指定泛型类型的子类型，或实现了指定泛型接口。
        /// </summary>
        /// <param name="type">需要测试的类型。</param>
        /// <param name="generic">泛型接口类型，传入 typeof(IXxx&lt;&gt;)</param>
        /// <returns>如果是泛型接口的子类型，则返回 true，否则返回 false。</returns>
        public static bool HasImplementedRawGeneric([NotNull] this Type type, [NotNull] Type generic)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (generic == null) throw new ArgumentNullException(nameof(generic));


            var faces = type.GetInterfaces();

            var rel = faces.Any(t =>
            {
                if (t.IsGenericType)
                {
                    return t.GetGenericTypeDefinition().FullName == generic.FullName;
                }
                else
                    return false;
            });

            return rel;
        }

        /// <summary>
        /// 获取泛型类名称
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetGenericTypeName(this Type type)
        {
            var genericName = "";
            if (type.IsGenericType)
            {
                genericName = string.Join('|', type.GetGenericArguments().Select(c => c.Name));
            }

            return $"{type.Name}: {genericName}";
        }
    }
}
