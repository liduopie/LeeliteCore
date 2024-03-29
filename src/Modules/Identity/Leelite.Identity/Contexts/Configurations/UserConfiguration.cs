﻿using System;
using System.Linq;

using Leelite.Identity.Models.UserAgg;
using Leelite.Identity.Models.UserClaimAgg;
using Leelite.Identity.Models.UserFingerprintAgg;
using Leelite.Identity.Models.UserLoginAgg;
using Leelite.Identity.Models.UserRoleAgg;
using Leelite.Identity.Models.UserTokenAgg;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leelite.Identity.Contexts.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        private readonly StoreOptions _storeOptions;
        private readonly PersonalDataConverter _dataConverter;
        public UserConfiguration(StoreOptions storeOptions, PersonalDataConverter dataConverter)
        {
            _storeOptions = storeOptions;
            _dataConverter = dataConverter;
        }

        public void Configure(EntityTypeBuilder<User> builder)
        {
            var nameMaxLength = 32;

            builder.HasKey(u => u.Id);
            builder.ToTable(TableConsts.IdentityUsers);

            builder.Property(u => u.NickName).HasMaxLength(nameMaxLength);
            builder.Property(u => u.RealName).HasMaxLength(nameMaxLength);
            builder.Property(u => u.Sex).HasMaxLength(1);

            builder.Property(u => u.ProfilePicture).HasMaxLength(1024);

            builder.Property(u => u.SecurityStamp).HasMaxLength(256);
            builder.Property(u => u.ConcurrencyStamp).HasMaxLength(256).IsConcurrencyToken();

            builder.OwnsOne(u => u.Lock, l =>
            {
                l.Property(p => p.LockoutEnd).HasColumnName("LockoutEnd");
                l.Property(p => p.LockoutEnabled).HasColumnName("LockoutEnabled");
            });

            builder.ComplexProperty(u => u.Account, a =>
            {
                a.IsRequired();
                a.Property(p => p.UserName).HasColumnName("UserName").HasMaxLength(nameMaxLength);
                a.Property(p => p.NormalizedUserName).HasColumnName("NormalizedUserName").HasMaxLength(nameMaxLength);

                // a.HasIndex(p => p.NormalizedUserName).HasDatabaseName("UserNameIndex").IsUnique();
            });

            builder.ComplexProperty(u => u.Password, pa =>
            {
                pa.IsRequired();
                pa.Property(p => p.PasswordHash).HasColumnName("PasswordHash").HasMaxLength(1024);
            });

            builder.ComplexProperty(u => u.Phone, ph =>
            {
                ph.IsRequired();
                ph.Property(p => p.PhoneNumber).HasColumnName("PhoneNumber").HasMaxLength(64);
                ph.Property(p => p.PhoneNumberConfirmed).HasColumnName("PhoneNumberConfirmed").HasMaxLength(64);
            });

            builder.ComplexProperty(u => u.Email, e =>
            {
                e.IsRequired();
                e.Property(p => p.Email).HasColumnName("Email").HasMaxLength(nameMaxLength);
                e.Property(p => p.NormalizedEmail).HasColumnName("NormalizedEmail").HasMaxLength(nameMaxLength);
                e.Property(p => p.EmailConfirmed).HasColumnName("EmailConfirmed").HasMaxLength(nameMaxLength);

                // e.HasIndex(p => p.NormalizedEmail).HasDatabaseName("EmailIndex");
            });

            builder.ComplexProperty(u => u.IDCard, i =>
            {
                i.IsRequired();
                i.Property(p => p.Ethnicity).HasColumnName("Ethnicity").HasMaxLength(32);
                i.Property(p => p.Address).HasColumnName("Address").HasMaxLength(256);
                i.Property(p => p.IDNumber).HasColumnName("IDNumber").HasMaxLength(32);
                i.Property(p => p.IssuingAuthority).HasColumnName("IssuingAuthority").HasMaxLength(64);
                i.Property(p => p.StartDate).HasColumnName("StartDate");
                i.Property(p => p.EndDate).HasColumnName("EndDate");
                i.Property(p => p.Photo).HasColumnName("Photo");
                i.Property(p => p.Fingerprint).HasColumnName("Fingerprint");
            });

            builder.ComplexProperty(u => u.Facial, f =>
            {
                f.IsRequired();
                f.Property(p => p.FeatureCode).HasColumnName("FeatureCode");
            });

            builder.HasAudit<User, long>(nameMaxLength);
            builder.HasEnabled();
            builder.HasSoftDelete();

            if (_storeOptions.ProtectPersonalData)
            {
                var personalDataProps = typeof(User).GetProperties().Where(
                                prop => Attribute.IsDefined(prop, typeof(ProtectedPersonalDataAttribute)));
                foreach (var p in personalDataProps)
                {
                    if (p.PropertyType != typeof(string))
                    {
                        throw new InvalidOperationException(Resources.CanOnlyProtectStrings);
                    }
                    builder.Property(typeof(string), p.Name).HasConversion(_dataConverter);
                }
            }

            builder.HasMany<UserClaim>().WithOne().HasForeignKey(c => c.UserId).IsRequired();
            builder.HasMany<UserFingerprint>().WithOne().HasForeignKey(c => c.UserId).IsRequired();
            builder.HasMany<UserLogin>().WithOne().HasForeignKey(c => c.UserId).IsRequired();
            builder.HasMany<UserToken>().WithOne().HasForeignKey(c => c.UserId).IsRequired();
            builder.HasMany<UserRole>().WithOne().HasForeignKey(c => c.UserId).IsRequired();
        }
    }
}
