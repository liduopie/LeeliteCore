﻿using System;
using System.Linq;

using Leelite.Identity.Models.UserTokenAgg;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leelite.Identity.Contexts.Configurations
{
    public class UserTokenConfiguration : IEntityTypeConfiguration<UserToken>
    {
        private readonly StoreOptions _storeOptions;
        private readonly PersonalDataConverter _dataConverter;
        public UserTokenConfiguration(StoreOptions storeOptions, PersonalDataConverter dataConverter)
        {
            _storeOptions = storeOptions;
            _dataConverter = dataConverter;
        }

        public void Configure(EntityTypeBuilder<UserToken> builder)
        {
            builder.Ignore("Id");
            builder.HasKey(c => new { c.UserId, c.LoginProvider, c.Name });
            builder.ToTable(TableConsts.IdentityUserTokens);

            if (_storeOptions.MaxLengthForKeys > 0)
            {
                builder.Property(p => p.LoginProvider).HasMaxLength(_storeOptions.MaxLengthForKeys);
                builder.Property(p => p.Name).HasMaxLength(_storeOptions.MaxLengthForKeys);
            }

            builder.Property(t => t.Value).HasMaxLength(256);

            if (_storeOptions.ProtectPersonalData)
            {
                var tokenProps = typeof(UserToken).GetProperties().Where(
                                prop => Attribute.IsDefined(prop, typeof(ProtectedPersonalDataAttribute)));
                foreach (var p in tokenProps)
                {
                    if (p.PropertyType != typeof(string))
                    {
                        throw new InvalidOperationException(Resources.CanOnlyProtectStrings);
                    }
                    builder.Property(typeof(string), p.Name).HasConversion(_dataConverter);
                }
            }
        }
    }
}
