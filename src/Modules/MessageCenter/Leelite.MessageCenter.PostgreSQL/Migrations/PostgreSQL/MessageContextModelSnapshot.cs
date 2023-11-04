﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Leelite.MessageCenter.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Leelite.MessageCenter.Migrations.PostgreSQL
{
    [DbContext(typeof(MessageContext))]
    partial class MessageContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-rc.2.23480.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Leelite.MessageCenter.Models.MessageAgg.Message", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Data")
                        .HasColumnType("json");

                    b.Property<DateTime>("DeleteTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("DeliveryState")
                        .HasColumnType("boolean");

                    b.Property<string>("Description")
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.Property<DateTime>("ExpirationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("GenerateRecord")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("MessageTypeId")
                        .HasColumnType("integer");

                    b.Property<bool>("ReadState")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ReadTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("SessionId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("MessageCenter_Message", (string)null);
                });

            modelBuilder.Entity("Leelite.MessageCenter.Models.MessageTopicAgg.MessageTopic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("Icon")
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.ToTable("MessageCenter_Topic", (string)null);
                });

            modelBuilder.Entity("Leelite.MessageCenter.Models.MessageTypeAgg.MessageType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("DescriptionTemplate")
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<IList<string>>("PushPlatform")
                        .HasColumnType("json");

                    b.Property<int>("PushStrategy")
                        .HasColumnType("integer");

                    b.Property<string>("Schema")
                        .HasColumnType("text");

                    b.Property<string>("TitleTemplate")
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.Property<string>("Topic")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<int>("ValidDays")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("MessageCenter_Type", (string)null);
                });

            modelBuilder.Entity("Leelite.MessageCenter.Models.PushPlatformAgg.PushPlatform", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<IDictionary<string, string>>("Config")
                        .HasColumnType("json");

                    b.Property<string>("Description")
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<int>("Priority")
                        .HasColumnType("integer");

                    b.Property<string>("ProviderName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.ToTable("MessageCenter_Platform", (string)null);
                });

            modelBuilder.Entity("Leelite.MessageCenter.Models.PushRecordAgg.PushRecord", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("ExpirationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("MessageId")
                        .HasColumnType("bigint");

                    b.Property<int>("PlatformId")
                        .HasColumnType("integer");

                    b.Property<string>("Remark")
                        .HasColumnType("text");

                    b.Property<int>("RetriesNum")
                        .HasColumnType("integer");

                    b.Property<int>("State")
                        .HasColumnType("integer");

                    b.Property<string>("TemplateCode")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("Url")
                        .HasColumnType("text");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("MessageCenter_Record", (string)null);
                });

            modelBuilder.Entity("Leelite.MessageCenter.Models.SessionAgg.Session", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CompleteTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Data")
                        .HasColumnType("json");

                    b.Property<string>("Description")
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.Property<DateTime>("ExpirationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("MessageTypeId")
                        .HasColumnType("integer");

                    b.Property<int>("PushNum")
                        .HasColumnType("integer");

                    b.Property<string>("Remark")
                        .HasColumnType("text");

                    b.Property<int>("State")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<IList<long>>("UserIds")
                        .HasColumnType("json");

                    b.Property<int>("UserNum")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("MessageCenter_Session", (string)null);
                });

            modelBuilder.Entity("Leelite.MessageCenter.Models.TemplateAgg.Template", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ContentTemplate")
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.Property<string>("Description")
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.Property<string>("MessageTypeCode")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<int>("PlatformId")
                        .HasColumnType("integer");

                    b.Property<string>("TemplateCode")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("UrlTemplate")
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.HasKey("Id");

                    b.ToTable("MessageCenter_Template", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
