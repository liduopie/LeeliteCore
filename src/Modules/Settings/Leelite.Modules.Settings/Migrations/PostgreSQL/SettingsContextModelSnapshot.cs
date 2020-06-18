﻿// <auto-generated />
using Leelite.Modules.Settings.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Leelite.Modules.Settings.Migrations.PostgreSQL
{
    [DbContext(typeof(SettingsContext))]
    partial class SettingsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Leelite.Modules.Settings.Models.SettingValueAgg.SettingValue", b =>
                {
                    b.Property<long>("_tenantId")
                        .HasColumnName("TenantId")
                        .HasColumnType("bigint");

                    b.Property<long>("_userId")
                        .HasColumnName("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("_name")
                        .HasColumnName("Name")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Value")
                        .HasColumnType("character varying(1024)")
                        .HasMaxLength(1024);

                    b.HasKey("_tenantId", "_userId", "_name");

                    b.ToTable("Settings_SettingValue");
                });
#pragma warning restore 612, 618
        }
    }
}
