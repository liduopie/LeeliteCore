using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Leelite.IdentityServer.Migrations.PostgreSQL.Configurations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IdentityServer_ApiResource",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Enabled = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    DisplayName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    AllowedAccessTokenSigningAlgorithms = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ShowInDiscoveryDocument = table.Column<bool>(type: "boolean", nullable: false),
                    RequireResourceIndicator = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastAccessed = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NonEditable = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServer_ApiResource", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServer_ApiScope",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Enabled = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    DisplayName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    Required = table.Column<bool>(type: "boolean", nullable: false),
                    Emphasize = table.Column<bool>(type: "boolean", nullable: false),
                    ShowInDiscoveryDocument = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastAccessed = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NonEditable = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServer_ApiScope", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServer_Client",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Enabled = table.Column<bool>(type: "boolean", nullable: false),
                    ClientId = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    ProtocolType = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    RequireClientSecret = table.Column<bool>(type: "boolean", nullable: false),
                    ClientName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    ClientUri = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    LogoUri = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    RequireConsent = table.Column<bool>(type: "boolean", nullable: false),
                    AllowRememberConsent = table.Column<bool>(type: "boolean", nullable: false),
                    AlwaysIncludeUserClaimsInIdToken = table.Column<bool>(type: "boolean", nullable: false),
                    RequirePkce = table.Column<bool>(type: "boolean", nullable: false),
                    AllowPlainTextPkce = table.Column<bool>(type: "boolean", nullable: false),
                    RequireRequestObject = table.Column<bool>(type: "boolean", nullable: false),
                    AllowAccessTokensViaBrowser = table.Column<bool>(type: "boolean", nullable: false),
                    RequireDPoP = table.Column<bool>(type: "boolean", nullable: false),
                    DPoPValidationMode = table.Column<int>(type: "integer", nullable: false),
                    DPoPClockSkew = table.Column<TimeSpan>(type: "interval", nullable: false),
                    FrontChannelLogoutUri = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    FrontChannelLogoutSessionRequired = table.Column<bool>(type: "boolean", nullable: false),
                    BackChannelLogoutUri = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    BackChannelLogoutSessionRequired = table.Column<bool>(type: "boolean", nullable: false),
                    AllowOfflineAccess = table.Column<bool>(type: "boolean", nullable: false),
                    IdentityTokenLifetime = table.Column<int>(type: "integer", nullable: false),
                    AllowedIdentityTokenSigningAlgorithms = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    AccessTokenLifetime = table.Column<int>(type: "integer", nullable: false),
                    AuthorizationCodeLifetime = table.Column<int>(type: "integer", nullable: false),
                    ConsentLifetime = table.Column<int>(type: "integer", nullable: true),
                    AbsoluteRefreshTokenLifetime = table.Column<int>(type: "integer", nullable: false),
                    SlidingRefreshTokenLifetime = table.Column<int>(type: "integer", nullable: false),
                    RefreshTokenUsage = table.Column<int>(type: "integer", nullable: false),
                    UpdateAccessTokenClaimsOnRefresh = table.Column<bool>(type: "boolean", nullable: false),
                    RefreshTokenExpiration = table.Column<int>(type: "integer", nullable: false),
                    AccessTokenType = table.Column<int>(type: "integer", nullable: false),
                    EnableLocalLogin = table.Column<bool>(type: "boolean", nullable: false),
                    IncludeJwtId = table.Column<bool>(type: "boolean", nullable: false),
                    AlwaysSendClientClaims = table.Column<bool>(type: "boolean", nullable: false),
                    ClientClaimsPrefix = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    PairWiseSubjectSalt = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    InitiateLoginUri = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    UserSsoLifetime = table.Column<int>(type: "integer", nullable: true),
                    UserCodeType = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeviceCodeLifetime = table.Column<int>(type: "integer", nullable: false),
                    CibaLifetime = table.Column<int>(type: "integer", nullable: true),
                    PollingInterval = table.Column<int>(type: "integer", nullable: true),
                    CoordinateLifetimeWithUserSession = table.Column<bool>(type: "boolean", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastAccessed = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NonEditable = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServer_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServer_IdentityProvider",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Scheme = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    DisplayName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Enabled = table.Column<bool>(type: "boolean", nullable: false),
                    Type = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Properties = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastAccessed = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NonEditable = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServer_IdentityProvider", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServer_IdentityResource",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Enabled = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    DisplayName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    Required = table.Column<bool>(type: "boolean", nullable: false),
                    Emphasize = table.Column<bool>(type: "boolean", nullable: false),
                    ShowInDiscoveryDocument = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NonEditable = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServer_IdentityResource", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServer_ApiResourceClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApiResourceId = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServer_ApiResourceClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityServer_ApiResourceClaim_IdentityServer_ApiResource_~",
                        column: x => x.ApiResourceId,
                        principalTable: "IdentityServer_ApiResource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServer_ApiResourceProperty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApiResourceId = table.Column<int>(type: "integer", nullable: false),
                    Key = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Value = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServer_ApiResourceProperty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityServer_ApiResourceProperty_IdentityServer_ApiResour~",
                        column: x => x.ApiResourceId,
                        principalTable: "IdentityServer_ApiResource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServer_ApiResourceScope",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Scope = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    ApiResourceId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServer_ApiResourceScope", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityServer_ApiResourceScope_IdentityServer_ApiResource_~",
                        column: x => x.ApiResourceId,
                        principalTable: "IdentityServer_ApiResource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServer_ApiResourceSecret",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApiResourceId = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    Value = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: false),
                    Expiration = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Type = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServer_ApiResourceSecret", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityServer_ApiResourceSecret_IdentityServer_ApiResource~",
                        column: x => x.ApiResourceId,
                        principalTable: "IdentityServer_ApiResource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServer_ApiScopeClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ScopeId = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServer_ApiScopeClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityServer_ApiScopeClaim_IdentityServer_ApiScope_ScopeId",
                        column: x => x.ScopeId,
                        principalTable: "IdentityServer_ApiScope",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServer_ApiScopeProperty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ScopeId = table.Column<int>(type: "integer", nullable: false),
                    Key = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Value = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServer_ApiScopeProperty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityServer_ApiScopeProperty_IdentityServer_ApiScope_Sco~",
                        column: x => x.ScopeId,
                        principalTable: "IdentityServer_ApiScope",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServer_ClientClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Value = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    ClientId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServer_ClientClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityServer_ClientClaim_IdentityServer_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "IdentityServer_Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServer_ClientCorsOrigin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Origin = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    ClientId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServer_ClientCorsOrigin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityServer_ClientCorsOrigin_IdentityServer_Client_Clien~",
                        column: x => x.ClientId,
                        principalTable: "IdentityServer_Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServer_ClientGrantType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GrantType = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    ClientId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServer_ClientGrantType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityServer_ClientGrantType_IdentityServer_Client_Client~",
                        column: x => x.ClientId,
                        principalTable: "IdentityServer_Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServer_ClientIdPRestriction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Provider = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    ClientId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServer_ClientIdPRestriction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityServer_ClientIdPRestriction_IdentityServer_Client_C~",
                        column: x => x.ClientId,
                        principalTable: "IdentityServer_Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServer_ClientPostLogoutRedirectUri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PostLogoutRedirectUri = table.Column<string>(type: "character varying(400)", maxLength: 400, nullable: false),
                    ClientId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServer_ClientPostLogoutRedirectUri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityServer_ClientPostLogoutRedirectUri_IdentityServer_C~",
                        column: x => x.ClientId,
                        principalTable: "IdentityServer_Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServer_ClientProperty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClientId = table.Column<int>(type: "integer", nullable: false),
                    Key = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Value = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServer_ClientProperty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityServer_ClientProperty_IdentityServer_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "IdentityServer_Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServer_ClientRedirectUri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RedirectUri = table.Column<string>(type: "character varying(400)", maxLength: 400, nullable: false),
                    ClientId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServer_ClientRedirectUri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityServer_ClientRedirectUri_IdentityServer_Client_Clie~",
                        column: x => x.ClientId,
                        principalTable: "IdentityServer_Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServer_ClientScopes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Scope = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    ClientId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServer_ClientScopes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityServer_ClientScopes_IdentityServer_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "IdentityServer_Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServer_ClientSecret",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClientId = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    Value = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: false),
                    Expiration = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Type = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServer_ClientSecret", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityServer_ClientSecret_IdentityServer_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "IdentityServer_Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServer_IdentityResourceClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdentityResourceId = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServer_IdentityResourceClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityServer_IdentityResourceClaim_IdentityServer_Identit~",
                        column: x => x.IdentityResourceId,
                        principalTable: "IdentityServer_IdentityResource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServer_IdentityResourceProperty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdentityResourceId = table.Column<int>(type: "integer", nullable: false),
                    Key = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Value = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServer_IdentityResourceProperty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityServer_IdentityResourceProperty_IdentityServer_Iden~",
                        column: x => x.IdentityResourceId,
                        principalTable: "IdentityServer_IdentityResource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IdentityServer_ApiResource_Name",
                table: "IdentityServer_ApiResource",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IdentityServer_ApiResourceClaim_ApiResourceId_Type",
                table: "IdentityServer_ApiResourceClaim",
                columns: new[] { "ApiResourceId", "Type" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IdentityServer_ApiResourceProperty_ApiResourceId_Key",
                table: "IdentityServer_ApiResourceProperty",
                columns: new[] { "ApiResourceId", "Key" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IdentityServer_ApiResourceScope_ApiResourceId_Scope",
                table: "IdentityServer_ApiResourceScope",
                columns: new[] { "ApiResourceId", "Scope" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IdentityServer_ApiResourceSecret_ApiResourceId",
                table: "IdentityServer_ApiResourceSecret",
                column: "ApiResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityServer_ApiScope_Name",
                table: "IdentityServer_ApiScope",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IdentityServer_ApiScopeClaim_ScopeId_Type",
                table: "IdentityServer_ApiScopeClaim",
                columns: new[] { "ScopeId", "Type" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IdentityServer_ApiScopeProperty_ScopeId_Key",
                table: "IdentityServer_ApiScopeProperty",
                columns: new[] { "ScopeId", "Key" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IdentityServer_Client_ClientId",
                table: "IdentityServer_Client",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IdentityServer_ClientClaim_ClientId_Type_Value",
                table: "IdentityServer_ClientClaim",
                columns: new[] { "ClientId", "Type", "Value" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IdentityServer_ClientCorsOrigin_ClientId_Origin",
                table: "IdentityServer_ClientCorsOrigin",
                columns: new[] { "ClientId", "Origin" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IdentityServer_ClientGrantType_ClientId_GrantType",
                table: "IdentityServer_ClientGrantType",
                columns: new[] { "ClientId", "GrantType" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IdentityServer_ClientIdPRestriction_ClientId_Provider",
                table: "IdentityServer_ClientIdPRestriction",
                columns: new[] { "ClientId", "Provider" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IdentityServer_ClientPostLogoutRedirectUri_ClientId_PostLog~",
                table: "IdentityServer_ClientPostLogoutRedirectUri",
                columns: new[] { "ClientId", "PostLogoutRedirectUri" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IdentityServer_ClientProperty_ClientId_Key",
                table: "IdentityServer_ClientProperty",
                columns: new[] { "ClientId", "Key" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IdentityServer_ClientRedirectUri_ClientId_RedirectUri",
                table: "IdentityServer_ClientRedirectUri",
                columns: new[] { "ClientId", "RedirectUri" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IdentityServer_ClientScopes_ClientId_Scope",
                table: "IdentityServer_ClientScopes",
                columns: new[] { "ClientId", "Scope" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IdentityServer_ClientSecret_ClientId",
                table: "IdentityServer_ClientSecret",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityServer_IdentityProvider_Scheme",
                table: "IdentityServer_IdentityProvider",
                column: "Scheme",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IdentityServer_IdentityResource_Name",
                table: "IdentityServer_IdentityResource",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IdentityServer_IdentityResourceClaim_IdentityResourceId_Type",
                table: "IdentityServer_IdentityResourceClaim",
                columns: new[] { "IdentityResourceId", "Type" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IdentityServer_IdentityResourceProperty_IdentityResourceId_~",
                table: "IdentityServer_IdentityResourceProperty",
                columns: new[] { "IdentityResourceId", "Key" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityServer_ApiResourceClaim");

            migrationBuilder.DropTable(
                name: "IdentityServer_ApiResourceProperty");

            migrationBuilder.DropTable(
                name: "IdentityServer_ApiResourceScope");

            migrationBuilder.DropTable(
                name: "IdentityServer_ApiResourceSecret");

            migrationBuilder.DropTable(
                name: "IdentityServer_ApiScopeClaim");

            migrationBuilder.DropTable(
                name: "IdentityServer_ApiScopeProperty");

            migrationBuilder.DropTable(
                name: "IdentityServer_ClientClaim");

            migrationBuilder.DropTable(
                name: "IdentityServer_ClientCorsOrigin");

            migrationBuilder.DropTable(
                name: "IdentityServer_ClientGrantType");

            migrationBuilder.DropTable(
                name: "IdentityServer_ClientIdPRestriction");

            migrationBuilder.DropTable(
                name: "IdentityServer_ClientPostLogoutRedirectUri");

            migrationBuilder.DropTable(
                name: "IdentityServer_ClientProperty");

            migrationBuilder.DropTable(
                name: "IdentityServer_ClientRedirectUri");

            migrationBuilder.DropTable(
                name: "IdentityServer_ClientScopes");

            migrationBuilder.DropTable(
                name: "IdentityServer_ClientSecret");

            migrationBuilder.DropTable(
                name: "IdentityServer_IdentityProvider");

            migrationBuilder.DropTable(
                name: "IdentityServer_IdentityResourceClaim");

            migrationBuilder.DropTable(
                name: "IdentityServer_IdentityResourceProperty");

            migrationBuilder.DropTable(
                name: "IdentityServer_ApiResource");

            migrationBuilder.DropTable(
                name: "IdentityServer_ApiScope");

            migrationBuilder.DropTable(
                name: "IdentityServer_Client");

            migrationBuilder.DropTable(
                name: "IdentityServer_IdentityResource");
        }
    }
}
