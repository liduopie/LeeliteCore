using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Leelite.DataCategory.Migrations.PostgreSQL
{
    /// <inheritdoc />
    public partial class InitDataCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataCategory_Categories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryTypeId = table.Column<int>(type: "integer", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Icon = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Description = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    ParentId = table.Column<long>(type: "bigint", nullable: false),
                    Path = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    Sort = table.Column<int>(type: "integer", nullable: false),
                    IsLeaf = table.Column<bool>(type: "boolean", nullable: false),
                    ChildrenCount = table.Column<int>(type: "integer", nullable: false),
                    CreatorId = table.Column<long>(type: "bigint", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifierId = table.Column<long>(type: "bigint", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataCategory_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DataCategory_CategoryTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataCategory_CategoryTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataCategory_Categories_Name",
                table: "DataCategory_Categories",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataCategory_Categories");

            migrationBuilder.DropTable(
                name: "DataCategory_CategoryTypes");
        }
    }
}
