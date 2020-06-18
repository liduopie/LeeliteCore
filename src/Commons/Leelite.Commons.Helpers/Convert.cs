using System;
using System.Collections.Generic;
using System.Linq;

namespace Leelite.Commons.Helpers
{
    public static class Convert
    {
        /// <summary>
        /// 泛型集合转换
        /// </summary>
        /// <typeparam name="T">目标元素类型</typeparam>
        /// <param name="input">以逗号分隔的元素集合字符串，范例:83B0233C-A24F-49FD-8083-1337209EBC9A,EAB523C6-2FE7-47BE-89D5-C6D440C3033A</param>
        public static List<T> ToList<T>(string input)
        {
            var result = new List<T>();
            if (string.IsNullOrWhiteSpace(input))
                return result;
            var array = input.Split(',');
            result.AddRange(from each in array where !string.IsNullOrWhiteSpace(each) select To<T>(each));
            return result;
        }

        /// <summary>
        /// 通用泛型转换
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <param name="input">输入值</param>
        public static T To<T>(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return default;

            Type type = typeof(T);
            var typeName = type.Name;

            try
            {
                if (typeName == "guid")
                    return (T)(object)new Guid(input.ToString());
                if (type.IsEnum)
                    return (T)Enum.Parse(type, input);
                if (input is IConvertible)
                    return (T)System.Convert.ChangeType(input, type);
                return (T)(object)input;
            }
            catch
            {
                return default;
            }
        }
    }
}
