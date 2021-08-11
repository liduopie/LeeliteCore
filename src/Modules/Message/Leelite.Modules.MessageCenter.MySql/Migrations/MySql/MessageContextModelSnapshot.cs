﻿// <auto-generated />
using System;
using Leelite.Modules.MessageCenter.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Leelite.Modules.MessageCenter.Migrations.MySql
{
    [DbContext(typeof(MessageContext))]
    partial class MessageContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("Leelite.Modules.MessageCenter.Models.MessageAgg.Message", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Data")
                        .HasColumnType("json");

                    b.Property<DateTime>("DeleteTime")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("DeliveryState")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Description")
                        .HasMaxLength(512)
                        .HasColumnType("varchar(512)");

                    b.Property<DateTime>("ExpirationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("MessageTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("ReadState")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("ReadTime")
                        .HasColumnType("datetime(6)");

                    b.Property<long>("SessionId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("Leelite.Modules.MessageCenter.Models.MessageTopicAgg.MessageTopic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("Icon")
                        .HasMaxLength(512)
                        .HasColumnType("varchar(512)");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.ToTable("Message_Topic");
                });

            modelBuilder.Entity("Leelite.Modules.MessageCenter.Models.MessageTypeAgg.MessageType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("DescriptionTemplate")
                        .HasMaxLength(512)
                        .HasColumnType("varchar(512)");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PushPlatform")
                        .HasColumnType("json");

                    b.Property<int>("PushStrategy")
                        .HasColumnType("int");

                    b.Property<string>("Schema")
                        .HasColumnType("longtext");

                    b.Property<string>("TitleTemplate")
                        .HasMaxLength(512)
                        .HasColumnType("varchar(512)");

                    b.Property<string>("Topic")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<int>("ValidDays")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Message_Type");
                });

            modelBuilder.Entity("Leelite.Modules.MessageCenter.Models.PlatformAgg.PushPlatform", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("Config")
                        .HasColumnType("json");

                    b.Property<string>("Description")
                        .HasMaxLength(512)
                        .HasColumnType("varchar(512)");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<string>("ProviderName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.ToTable("Message_Push_Platform");
                });

            modelBuilder.Entity("Leelite.Modules.MessageCenter.Models.PushRecordAgg.PushRecord", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Content")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("ExpirationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<long>("MessageId")
                        .HasColumnType("bigint");

                    b.Property<int>("PlatformId")
                        .HasColumnType("int");

                    b.Property<string>("Remark")
                        .HasColumnType("longtext");

                    b.Property<int>("RetriesNum")
                        .HasColumnType("int");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<string>("TemplateCode")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("Url")
                        .HasColumnType("longtext");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Message_Push_Record");
                });

            modelBuilder.Entity("Leelite.Modules.MessageCenter.Models.SessionAgg.Session", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CompleteTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Data")
                        .HasColumnType("json");

                    b.Property<string>("Description")
                        .HasMaxLength(512)
                        .HasColumnType("varchar(512)");

                    b.Property<DateTime>("ExpirationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("MessageTypeId")
                        .HasColumnType("int");

                    b.Property<int>("PushNum")
                        .HasColumnType("int");

                    b.Property<string>("Remark")
                        .HasColumnType("longtext");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("UserIds")
                        .HasColumnType("json");

                    b.Property<int>("UserNum")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Message_Session");
                });

            modelBuilder.Entity("Leelite.Modules.MessageCenter.Models.TemplateAgg.Template", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ContentTemplate")
                        .HasMaxLength(512)
                        .HasColumnType("varchar(512)");

                    b.Property<string>("Description")
                        .HasMaxLength(512)
                        .HasColumnType("varchar(512)");

                    b.Property<string>("MessageTypeCode")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<int>("PlatformId")
                        .HasColumnType("int");

                    b.Property<string>("TemplateCode")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("UrlTemplate")
                        .HasMaxLength(512)
                        .HasColumnType("varchar(512)");

                    b.HasKey("Id");

                    b.ToTable("Message_Template");
                });
#pragma warning restore 612, 618
        }
    }
}
