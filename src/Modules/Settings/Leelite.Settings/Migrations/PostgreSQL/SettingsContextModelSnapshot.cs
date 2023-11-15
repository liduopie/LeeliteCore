﻿// <auto-generated />
using Leelite.Settings.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Leelite.Settings.Migrations.PostgreSQL
{
    [DbContext(typeof(SettingsContext))]
    partial class SettingsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-rc.2.23480.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Leelite.Settings.Models.SettingValueAgg.SettingValue", b =>
                {
                    b.Property<long>("_tenantId")
                        .HasColumnType("bigint")
                        .HasColumnName("TenantId");

                    b.Property<long>("_userId")
                        .HasColumnType("bigint")
                        .HasColumnName("UserId");

                    b.Property<string>("_name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("Name");

                    b.Property<string>("Value")
                        .HasMaxLength(1024)
                        .HasColumnType("character varying(1024)");

                    b.HasKey("_tenantId", "_userId", "_name");

                    b.ToTable("Settings_SettingValues", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
