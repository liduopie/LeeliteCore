using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Leelite.Modules.IdentityServer.Migrations.PostgreSQL.Configurations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IdentityServer_ApiResources",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Enabled = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: true),
                    LastAccessed = table.Column<DateTime>(nullable: true),
                    NonEditable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServer_ApiResources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServer_Clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Enabled = table.Column<bool>(nullable: false),
                    ClientId = table.Column<string>(maxLength: 200, nullable: false),
                    ProtocolType = table.Column<string>(maxLength: 200, nullable: false),
                    RequireClientSecret = table.Column<bool>(nullable: false),
                    ClientName = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    ClientUri = table.Column<string>(maxLength: 2000, nullable: true),
                    LogoUri = table.Column<string>(maxLength: 2000, nullable: true),
                    RequireConsent = table.Column<bool>(nullable: false),
                    AllowRememberConsent = table.Column<bool>(nullable: false),
                    AlwaysIncludeUserClaimsInIdToken = table.Column<bool>(nullable: false),
                    RequirePkce = table.Column<bool>(nullable: false),
                    AllowPlainTextPkce = table.Column<bool>(nullable: false),
                    AllowAccessTokensViaBrowser = table.Column<bool>(nullable: false),
                    FrontChannelLogoutUri = table.Column<string>(maxLength: 2000, nullable: true),
                    FrontChannelLogoutSessionRequired = table.Column<bool>(nullable: false),
                    BackChannelLogoutUri = table.Column<string>(maxLength: 2000, nullable: true),
                    BackChannelLogoutSessionRequired = table.Column<bool>(nullable: false),
                    AllowOfflineAccess = table.Column<bool>(nullable: false),
                    IdentityTokenLifetime = table.Column<int>(nullable: false),
                    AccessTokenLifetime = table.Column<int>(nullable: false),
                    AuthorizationCodeLifetime = table.Column<int>(nullable: false),
                    ConsentLifetime = table.Column<int>(nullable: true),
                    AbsoluteRefreshTokenLifetime = table.Column<int>(nullable: false),
                    SlidingRefreshTokenLifetime = table.Column<int>(nullable: false),
                    RefreshTokenUsage = table.Column<int>(nullable: false),
                    UpdateAccessTokenClaimsOnRefresh = table.Column<bool>(nullable: false),
                    RefreshTokenExpiration = table.Column<int>(nullable: false),
                    AccessTokenType = table.Column<int>(nullable: false),
                    EnableLocalLogin = table.Column<bool>(nullable: false),
                    IncludeJwtId = table.Column<bool>(nullable: false),
                    AlwaysSendClientClaims = table.Column<bool>(nullable: false),
                    ClientClaimsPrefix = table.Column<string>(maxLength: 200, nullable: true),
                    PairWiseSubjectSalt = table.Column<string>(maxLength: 200, nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: true),
                    LastAccessed = table.Column<DateTime>(nullable: true),
                    UserSsoLifetime = table.Column<int>(nullable: true),
                    UserCodeType = table.Column<string>(maxLength: 100, nullable: true),
                    DeviceCodeLifetime = table.Column<int>(nullable: false),
                    NonEditable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServer_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServer_IdentityResources",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Enabled = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Required = table.Column<bool>(nullable: false),
                    Emphasize = table.Column<bool>(nullable: false),
                    ShowInDiscoveryDocument = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: true),
                    NonEditable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServer_IdentityResources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApiProperties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Key = table.Column<string>(maxLength: 250, nullable: false),
                    Value = table.Column<string>(maxLength: 2000, nullable: false),
                    ApiResourceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApiProperties_IdentityServer_ApiResources_ApiResourceId",
                        column: x => x.ApiResourceId,
                        principalTable: "IdentityServer_ApiResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServer_ApiClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(maxLength: 200, nullable: false),
                    ApiResourceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServer_ApiClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityServer_ApiClaims_IdentityServer_ApiResources_ApiRes~",
                        column: x => x.ApiResourceId,
                        principalTable: "IdentityServer_ApiResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServer_ApiScopes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Required = table.Column<bool>(nullable: false),
                    Emphasize = table.Column<bool>(nullable: false),
                    ShowInDiscoveryDocument = table.Column<bool>(nullable: false),
                    ApiResourceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServer_ApiScopes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityServer_ApiScopes_IdentityServer_ApiResources_ApiRes~",
                        column: x => x.ApiResourceId,
                        principalTable: "IdentityServer_ApiResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServer_ApiSecrets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Value = table.Column<string>(maxLength: 4000, nullable: false),
                    Expiration = table.Column<DateTime>(nullable: true),
                    Type = table.Column<string>(maxLength: 250, nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    ApiResourceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServer_ApiSecrets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityServer_ApiSecrets_IdentityServer_ApiResources_ApiRe~",
                        column: x => x.ApiResourceId,
                        principalTable: "IdentityServer_ApiResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServer_ClientClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(maxLength: 250, nullable: false),
                    Value = table.Column<string>(maxLength: 250, nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServer_ClientClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityServer_ClientClaims_IdentityServer_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "IdentityServer_Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServer_ClientCorsOrigins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Origin = table.Column<string>(maxLength: 150, nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServer_ClientCorsOrigins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityServer_ClientCorsOrigins_IdentityServer_Clients_Cli~",
                        column: x => x.ClientId,
                        principalTable: "IdentityServer_Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServer_ClientGrantTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GrantType = table.Column<string>(maxLength: 250, nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServer_ClientGrantTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityServer_ClientGrantTypes_IdentityServer_Clients_Clie~",
                        column: x => x.ClientId,
                        principalTable: "IdentityServer_Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServer_ClientIdPRestrictions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Provider = table.Column<string>(maxLength: 200, nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServer_ClientIdPRestrictions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityServer_ClientIdPRestrictions_IdentityServer_Clients~",
                        column: x => x.ClientId,
                        principalTable: "IdentityServer_Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServer_ClientPostLogoutRedirectUris",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PostLogoutRedirectUri = table.Column<string>(maxLength: 2000, nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServer_ClientPostLogoutRedirectUris", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityServer_ClientPostLogoutRedirectUris_IdentityServer_~",
                        column: x => x.ClientId,
                        principalTable: "IdentityServer_Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServer_ClientProperties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Key = table.Column<string>(maxLength: 250, nullable: false),
                    Value = table.Column<string>(maxLength: 2000, nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServer_ClientProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityServer_ClientProperties_IdentityServer_Clients_Clie~",
                        column: x => x.ClientId,
                        principalTable: "IdentityServer_Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServer_ClientRedirectUris",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RedirectUri = table.Column<string>(maxLength: 2000, nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServer_ClientRedirectUris", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityServer_ClientRedirectUris_IdentityServer_Clients_Cl~",
                        column: x => x.ClientId,
                        principalTable: "IdentityServer_Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServer_ClientScopes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Scope = table.Column<string>(maxLength: 200, nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServer_ClientScopes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityServer_ClientScopes_IdentityServer_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "IdentityServer_Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServer_ClientSecrets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(maxLength: 2000, nullable: true),
                    Value = table.Column<string>(maxLength: 4000, nullable: false),
                    Expiration = table.Column<DateTime>(nullable: true),
                    Type = table.Column<string>(maxLength: 250, nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServer_ClientSecrets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityServer_ClientSecrets_IdentityServer_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "IdentityServer_Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityProperties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Key = table.Column<string>(maxLength: 250, nullable: false),
                    Value = table.Column<string>(maxLength: 2000, nullable: false),
                    IdentityResourceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityProperties_IdentityServer_IdentityResources_Identit~",
                        column: x => x.IdentityResourceId,
                        principalTable: "IdentityServer_IdentityResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServer_IdentityClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(maxLength: 200, nullable: false),
                    IdentityResourceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServer_IdentityClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityServer_IdentityClaims_IdentityServer_IdentityResour~",
                        column: x => x.IdentityResourceId,
                        principalTable: "IdentityServer_IdentityResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServer_ApiScopeClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(maxLength: 200, nullable: false),
                    ApiScopeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServer_ApiScopeClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityServer_ApiScopeClaims_IdentityServer_ApiScopes_ApiS~",
                        column: x => x.ApiScopeId,
                        principalTable: "IdentityServer_ApiScopes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApiProperties_ApiResourceId",
                table: "ApiProperties",
                column: "ApiResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityProperties_IdentityResourceId",
                table: "IdentityProperties",
                column: "IdentityResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityServer_ApiClaims_ApiResourceId",
                table: "IdentityServer_ApiClaims",
                column: "ApiResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityServer_ApiResources_Name",
                table: "IdentityServer_ApiResources",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IdentityServer_ApiScopeClaims_ApiScopeId",
                table: "IdentityServer_ApiScopeClaims",
                column: "ApiScopeId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityServer_ApiScopes_ApiResourceId",
                table: "IdentityServer_ApiScopes",
                column: "ApiResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityServer_ApiScopes_Name",
                table: "IdentityServer_ApiScopes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IdentityServer_ApiSecrets_ApiResourceId",
                table: "IdentityServer_ApiSecrets",
                column: "ApiResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityServer_ClientClaims_ClientId",
                table: "IdentityServer_ClientClaims",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityServer_ClientCorsOrigins_ClientId",
                table: "IdentityServer_ClientCorsOrigins",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityServer_ClientGrantTypes_ClientId",
                table: "IdentityServer_ClientGrantTypes",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityServer_ClientIdPRestrictions_ClientId",
                table: "IdentityServer_ClientIdPRestrictions",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityServer_ClientPostLogoutRedirectUris_ClientId",
                table: "IdentityServer_ClientPostLogoutRedirectUris",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityServer_ClientProperties_ClientId",
                table: "IdentityServer_ClientProperties",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityServer_ClientRedirectUris_ClientId",
                table: "IdentityServer_ClientRedirectUris",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityServer_Clients_ClientId",
                table: "IdentityServer_Clients",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IdentityServer_ClientScopes_ClientId",
                table: "IdentityServer_ClientScopes",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityServer_ClientSecrets_ClientId",
                table: "IdentityServer_ClientSecrets",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityServer_IdentityClaims_IdentityResourceId",
                table: "IdentityServer_IdentityClaims",
                column: "IdentityResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityServer_IdentityResources_Name",
                table: "IdentityServer_IdentityResources",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApiProperties");

            migrationBuilder.DropTable(
                name: "IdentityProperties");

            migrationBuilder.DropTable(
                name: "IdentityServer_ApiClaims");

            migrationBuilder.DropTable(
                name: "IdentityServer_ApiScopeClaims");

            migrationBuilder.DropTable(
                name: "IdentityServer_ApiSecrets");

            migrationBuilder.DropTable(
                name: "IdentityServer_ClientClaims");

            migrationBuilder.DropTable(
                name: "IdentityServer_ClientCorsOrigins");

            migrationBuilder.DropTable(
                name: "IdentityServer_ClientGrantTypes");

            migrationBuilder.DropTable(
                name: "IdentityServer_ClientIdPRestrictions");

            migrationBuilder.DropTable(
                name: "IdentityServer_ClientPostLogoutRedirectUris");

            migrationBuilder.DropTable(
                name: "IdentityServer_ClientProperties");

            migrationBuilder.DropTable(
                name: "IdentityServer_ClientRedirectUris");

            migrationBuilder.DropTable(
                name: "IdentityServer_ClientScopes");

            migrationBuilder.DropTable(
                name: "IdentityServer_ClientSecrets");

            migrationBuilder.DropTable(
                name: "IdentityServer_IdentityClaims");

            migrationBuilder.DropTable(
                name: "IdentityServer_ApiScopes");

            migrationBuilder.DropTable(
                name: "IdentityServer_Clients");

            migrationBuilder.DropTable(
                name: "IdentityServer_IdentityResources");

            migrationBuilder.DropTable(
                name: "IdentityServer_ApiResources");
        }
    }
}
