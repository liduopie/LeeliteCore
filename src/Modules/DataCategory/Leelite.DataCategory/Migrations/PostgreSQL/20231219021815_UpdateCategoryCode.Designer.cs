﻿// <auto-generated />
using System;
using Leelite.DataCategory.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Leelite.DataCategory.Migrations.PostgreSQL
{
    [DbContext(typeof(DataCategoryContext))]
    [Migration("20231219021815_UpdateCategoryCode")]
    partial class UpdateCategoryCode
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Leelite.DataCategory.Models.CategoryAgg.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("CategoryTypeId")
                        .HasColumnType("integer");

                    b.Property<int>("ChildrenCount")
                        .HasColumnType("integer");

                    b.Property<string>("Code")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<DateTime?>("CreationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Creator")
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)");

                    b.Property<long>("CreatorId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.Property<string>("Icon")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsLeaf")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("LastModifierId")
                        .HasColumnType("bigint");

                    b.Property<int>("Level")
                        .HasColumnType("integer");

                    b.Property<string>("Modifier")
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<long>("ParentId")
                        .HasColumnType("bigint");

                    b.Property<string>("Path")
                        .HasMaxLength(1024)
                        .HasColumnType("character varying(1024)");

                    b.Property<int>("Sort")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("DataCategory_Categories", (string)null);
                });

            modelBuilder.Entity("Leelite.DataCategory.Models.CategoryTypeAgg.CategoryType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.ToTable("DataCategory_CategoryTypes", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
