using System;
using System.Collections.Generic;
using Leelite.Framework.Domain.Aggregate;
using Leelite.Framework.Domain.Model;

namespace Leelite.Modules.Settings.Models.SettingValueAgg
{
    /// <summary>
    /// Represents a setting information.
    /// </summary>
    [Serializable]
    public class SettingValue : AggregateRoot<SettingValueKey>
    {
        private long _tenantId;
        private long _userId;
        private string _name;

        /// <inheritdoc/>
        public override SettingValueKey Id
        {
            get
            {
                return new SettingValueKey()
                {
                    TenantId = _tenantId,
                    UserId = _userId,
                    Name = _name
                };
            }
            set
            {
                _tenantId = value.TenantId;
                _userId = value.UserId;
                _name = value.Name;
            }
        }

        /// <summary>
        /// Value of the setting.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Creates a new <see cref="SettingInfo"/> object.
        /// </summary>
        public SettingValue()
        {

        }

        /// <summary>
        /// Creates a new <see cref="SettingInfo"/> object.
        /// </summary>
        /// <param name="tenantId">TenantId for this setting. TenantId is null if this setting is not Tenant level.</param>
        /// <param name="userId">UserId for this setting. UserId is null if this setting is not user level.</param>
        /// <param name="name">Unique name of the setting</param>
        /// <param name="value">Value of the setting</param>
        public SettingValue(int tenantId, long userId, string name, string value)
        {
            Id.TenantId = tenantId;
            Id.UserId = userId;
            Id.Name = name;
            Value = value;
        }
    }

    public class SettingValueKey : ValueObject<SettingValueKey>
    {
        /// <summary>
        /// TenantId for this setting.
        /// TenantId is null if this setting is not Tenant level.
        /// </summary>
        public long TenantId { get; set; }

        /// <summary>
        /// UserId for this setting.
        /// UserId is null if this setting is not user level.
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Unique name of the setting.
        /// </summary>
        public string Name { get; set; }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            return new object[] { TenantId, UserId, Name };
        }
    }
}
