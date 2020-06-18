﻿// <auto-generated />
using System;
using Leelite.Modules.FileStorage.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Leelite.Modules.FileStorage.Migrations.PostgreSQL
{
    [DbContext(typeof(FileStorageContext))]
    partial class FileStorageContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Leelite.Modules.FileStorage.Models.FileItemAgg.FileItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreationTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Creator")
                        .HasColumnType("character varying(32)")
                        .HasMaxLength(32);

                    b.Property<long>("CreatorId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("LastModifierId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("LastVisitTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("Length")
                        .HasColumnType("bigint");

                    b.Property<string>("MD5")
                        .HasColumnType("character varying(32)")
                        .HasMaxLength(32);

                    b.Property<string>("Modifier")
                        .HasColumnType("character varying(32)")
                        .HasMaxLength(32);

                    b.Property<string>("ModuleCode")
                        .HasColumnType("character varying(32)")
                        .HasMaxLength(32);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Path")
                        .HasColumnType("character varying(1024)")
                        .HasMaxLength(1024);

                    b.Property<int>("State")
                        .HasColumnType("integer");

                    b.Property<long>("TenantId")
                        .HasColumnType("bigint");

                    b.Property<long>("Visits")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("FileStorage_FileItem");
                });
#pragma warning restore 612, 618
        }
    }
}
