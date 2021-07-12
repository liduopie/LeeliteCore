﻿// <auto-generated />
using System;
using Leelite.Modules.MessageCenter.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Leelite.Modules.MessageCenter.Migrations.PostgreSQL
{
    [DbContext(typeof(MessageContext))]
    partial class MessageContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Leelite.Modules.MessageCenter.Models.MessageAgg.Message", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Data")
                        .HasColumnType("text");

                    b.Property<DateTime>("DeleteTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("DeliveryState")
                        .HasColumnType("boolean");

                    b.Property<string>("Description")
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.Property<DateTime>("ExpirationTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("MessageTypeId")
                        .HasColumnType("integer");

                    b.Property<bool>("ReadState")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ReadTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Title")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("Leelite.Modules.MessageCenter.Models.MessageTypeAgg.MessageType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Code")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("DescriptionTemplate")
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.Property<string>("Icon")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PushPlatform")
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.Property<int>("PushStrategy")
                        .HasColumnType("integer");

                    b.Property<string>("Schema")
                        .HasColumnType("text");

                    b.Property<string>("TitleTemplate")
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.Property<int>("ValidDays")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Message_Type");
                });

            modelBuilder.Entity("Leelite.Modules.MessageCenter.Models.PlatformAgg.PushPlatform", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Config")
                        .HasColumnType("text");

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

                    b.ToTable("Message_Push_Platform");
                });

            modelBuilder.Entity("Leelite.Modules.MessageCenter.Models.PushRecordAgg.PushRecord", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<long>("MessageId")
                        .HasColumnType("bigint");

                    b.Property<int>("PlatformId")
                        .HasColumnType("integer");

                    b.Property<bool>("PushState")
                        .HasColumnType("boolean");

                    b.Property<string>("Remark")
                        .HasColumnType("text");

                    b.Property<int>("RetriesNum")
                        .HasColumnType("integer");

                    b.Property<string>("Url")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Message_Push_Record");
                });

            modelBuilder.Entity("Leelite.Modules.MessageCenter.Models.SessionAgg.Session", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CompleteTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Data")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.Property<DateTime>("ExpirationTime")
                        .HasColumnType("timestamp without time zone");

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

                    b.Property<string>("UserIds")
                        .HasColumnType("text");

                    b.Property<int>("UserNum")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Message_Session");
                });

            modelBuilder.Entity("Leelite.Modules.MessageCenter.Models.TemplateAgg.Template", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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

                    b.ToTable("Message_Template");
                });
#pragma warning restore 612, 618
        }
    }
}
