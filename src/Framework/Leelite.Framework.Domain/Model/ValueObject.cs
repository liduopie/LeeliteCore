using System;
using System.Collections.Generic;
using System.Linq;

namespace Leelite.Framework.Domain.Model
{
    /// <summary>
    /// 值对象基类，提供比较器和HasCode实现。
    /// </summary>
    /// <typeparam name="T">值对象的类型</typeparam>
    public abstract class ValueObject<T> : IEquatable<T> where T : ValueObject<T>
    {
        protected abstract IEnumerable<object> GetAttributesToIncludeInEqualityCheck();

        /// <summary>
        /// <see cref="object.IEquatable{TValueObject}"/>
        /// </summary>
        /// <param name="other"><see cref="object.IEquatable{TValueObject}"/></param>
        /// <returns><see cref="object.IEquatable{TValueObject}"/></returns>
        public bool Equals(T other)
        {
            if (other == null) return false;

            // Same instances must be considered as equal
            if (ReferenceEquals(this, other)) return true;

            return GetAttributesToIncludeInEqualityCheck().SequenceEqual(other.GetAttributesToIncludeInEqualityCheck());
        }

        /// <summary>
        /// <see cref="object.Equals"/>
        /// </summary>
        /// <param name="obj"><see cref="object.Equals"/></param>
        /// <returns><see cref="object.Equals"/></returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as T);
        }

        /// <summary>
        /// <see cref="object.GetHashCode"/>
        /// </summary>
        /// <returns><see cref="object.GetHashCode"/></returns>
        public override int GetHashCode()
        {
            int hash = 17;
            foreach (var obj in GetAttributesToIncludeInEqualityCheck())
                hash = hash * 31 + (obj == null ? 0 : obj.GetHashCode());

            return hash;
        }

        public static bool operator ==(ValueObject<T> left, ValueObject<T> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ValueObject<T> left, ValueObject<T> right)
        {
            return !(left == right);
        }

    }
}
