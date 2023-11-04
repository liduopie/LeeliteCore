using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Leelite.MessageCenter.Migrations.PostgreSQL
{
    /// <inheritdoc />
    public partial class InitDbMessageCenter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MessageCenter_Message",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SessionId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    MessageTypeId = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Description = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    Data = table.Column<string>(type: "json", nullable: true),
                    GenerateRecord = table.Column<bool>(type: "boolean", nullable: false),
                    ReadState = table.Column<bool>(type: "boolean", nullable: false),
                    DeliveryState = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ReadTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeleteTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ExpirationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageCenter_Message", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MessageCenter_Platform",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Description = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    Code = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ProviderName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Config = table.Column<IDictionary<string, string>>(type: "json", nullable: true),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageCenter_Platform", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MessageCenter_Record",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    MessageId = table.Column<long>(type: "bigint", nullable: false),
                    PlatformId = table.Column<int>(type: "integer", nullable: false),
                    TemplateCode = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Content = table.Column<string>(type: "text", nullable: true),
                    Url = table.Column<string>(type: "text", nullable: true),
                    State = table.Column<int>(type: "integer", nullable: false),
                    RetriesNum = table.Column<int>(type: "integer", nullable: false),
                    Remark = table.Column<string>(type: "text", nullable: true),
                    ExpirationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageCenter_Record", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MessageCenter_Session",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MessageTypeId = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Description = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    Data = table.Column<string>(type: "json", nullable: true),
                    UserIds = table.Column<IList<long>>(type: "json", nullable: true),
                    UserNum = table.Column<int>(type: "integer", nullable: false),
                    PushNum = table.Column<int>(type: "integer", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    CompleteTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ExpirationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Remark = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageCenter_Session", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MessageCenter_Template",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlatformId = table.Column<int>(type: "integer", nullable: false),
                    MessageTypeCode = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Description = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    TemplateCode = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ContentTemplate = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    UrlTemplate = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageCenter_Template", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MessageCenter_Topic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Code = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Icon = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageCenter_Topic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MessageCenter_Type",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Code = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Topic = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    TitleTemplate = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    DescriptionTemplate = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    Schema = table.Column<string>(type: "text", nullable: true),
                    PushStrategy = table.Column<int>(type: "integer", nullable: false),
                    PushPlatform = table.Column<IList<string>>(type: "json", nullable: true),
                    ValidDays = table.Column<int>(type: "integer", nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageCenter_Type", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MessageCenter_Message");

            migrationBuilder.DropTable(
                name: "MessageCenter_Platform");

            migrationBuilder.DropTable(
                name: "MessageCenter_Record");

            migrationBuilder.DropTable(
                name: "MessageCenter_Session");

            migrationBuilder.DropTable(
                name: "MessageCenter_Template");

            migrationBuilder.DropTable(
                name: "MessageCenter_Topic");

            migrationBuilder.DropTable(
                name: "MessageCenter_Type");
        }
    }
}
