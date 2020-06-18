using System;

namespace Leelite.Framework.Domain.Model
{
    /// <summary>
    /// IEntity 接口基本实现。
    /// 实体可以直接继承该类实现 <see cref="IEntity{TKey}"/>。
    /// </summary>
    /// <typeparam name="TKey">实体的主键类型。</typeparam>
    public abstract class Entity<TKey> : IEntity<TKey>, IEquatable<Entity<TKey>>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// 该实体的唯一标识。
        /// </summary>
        public virtual TKey Id { get; set; }

        /// <summary>
        /// 检查该实体是暂时的 (没有保存到数据库，它没有 <see cref="Id"/>)。
        /// </summary>
        /// <returns>True, 该实体是暂时的。</returns>
        public virtual bool IsTransient()
        {
            if (Id == null) return true;

            if (Id.Equals(default)) return true;

            Type type = typeof(TKey);

            var empty = type.Assembly.CreateInstance(type.FullName);

            return empty.Equals(Id);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("[{0} {1}]", GetType().Name, Id);
        }

        /// 如果在Service层面使用用Entity模型作为Dto或Dto的一部分，
        /// 如果对象中存在不同类型的对象Id相等会被Json序列化程序判定为循环引用。
        /// <inheritdoc/>
        public bool Equals(Entity<TKey> other)
        {
            if (other == null) return false;

            // Same instances must be considered as equal
            if (ReferenceEquals(this, other)) return true;

            // Transient objects are not considered as equal
            if (IsTransient() && other.IsTransient()) return false;

            return Id.Equals(other.Id);
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            var entity = obj as Entity<TKey>;

            if (ReferenceEquals(this, entity)) return true;
            if (entity is null) return false;

            return Id.Equals(entity.Id);
        }

        /// <inheritdoc/>
        public static bool operator ==(Entity<TKey> left, Entity<TKey> right)
        {
            if (Equals(left, null))
            {
                return Equals(right, null);
            }

            return left.Equals(right);
        }

        /// <inheritdoc/>
        public static bool operator !=(Entity<TKey> left, Entity<TKey> right)
        {
            return !(left == right);
        }
    }
}
