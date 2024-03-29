﻿using Duende.IdentityServer.EntityFramework.DbContexts;
using Duende.IdentityServer.EntityFramework.Entities;
using Duende.IdentityServer.EntityFramework.Options;

using Microsoft.EntityFrameworkCore;


namespace Leelite.IdentityServer.Contexts
{
    public class ConfigurationContext : ConfigurationDbContext<ConfigurationContext>
    {
        public ConfigurationContext(DbContextOptions<ConfigurationContext> options, ConfigurationStoreOptions storeOptions)
            : base(options)
        {
            storeOptions.ApiResource.Name = TableConsts.ApiResource;
            storeOptions.ApiResourceClaim.Name = TableConsts.ApiResourceClaim;
            storeOptions.ApiResourceProperty.Name = TableConsts.ApiResourceProperty;
            storeOptions.ApiResourceScope.Name = TableConsts.ApiResourceScope;
            storeOptions.ApiResourceSecret.Name = TableConsts.ApiResourceSecret;
            storeOptions.ApiScope.Name = TableConsts.ApiScope;
            storeOptions.ApiScopeClaim.Name = TableConsts.ApiScopeClaim;
            storeOptions.ApiScopeProperty.Name = TableConsts.ApiScopeProperty;
            storeOptions.Client.Name = TableConsts.Client;
            storeOptions.ClientClaim.Name = TableConsts.ClientClaim;
            storeOptions.ClientCorsOrigin.Name = TableConsts.ClientCorsOrigin;
            storeOptions.ClientGrantType.Name = TableConsts.ClientGrantType;
            storeOptions.ClientRedirectUri.Name = TableConsts.ClientRedirectUri;
            storeOptions.ClientIdPRestriction.Name = TableConsts.ClientIdPRestriction;
            storeOptions.ClientPostLogoutRedirectUri.Name = TableConsts.ClientPostLogoutRedirectUri;
            storeOptions.ClientProperty.Name = TableConsts.ClientProperty;
            storeOptions.ClientScopes.Name = TableConsts.ClientScopes;
            storeOptions.ClientSecret.Name = TableConsts.ClientSecret;
            storeOptions.IdentityResource.Name = TableConsts.IdentityResource;
            storeOptions.IdentityResourceClaim.Name = TableConsts.IdentityResourceClaim;
            storeOptions.IdentityResourceProperty.Name = TableConsts.IdentityResourceProperty;
            storeOptions.IdentityProvider.Name = TableConsts.IdentityProvider;
        }

        public DbSet<ApiResourceClaim> ApiResourceClaims { get; set; }
        public DbSet<ApiResourceProperty> ApiResourceProperties { get; set; }
        public DbSet<ApiResourceScope> ApiResourceScopes { get; set; }
        public DbSet<ApiResourceSecret> ApiSecrets { get; set; }
        public DbSet<ApiScopeClaim> ApiScopeClaims { get; set; }
        public DbSet<ApiScopeProperty> ApiScopeProperties { get; set; }
        public DbSet<ClientClaim> ClientClaims { get; set; }
        public DbSet<ClientGrantType> ClientGrantTypes { get; set; }
        public DbSet<ClientIdPRestriction> ClientIdPRestrictions { get; set; }
        public DbSet<ClientPostLogoutRedirectUri> ClientPostLogoutRedirectUris { get; set; }
        public DbSet<ClientProperty> ClientProperties { get; set; }
        public DbSet<ClientRedirectUri> ClientRedirectUris { get; set; }
        public DbSet<ClientScope> ClientScopes { get; set; }
        public DbSet<ClientSecret> ClientSecrets { get; set; }
        public DbSet<IdentityResourceClaim> IdentityClaims { get; set; }
        public DbSet<IdentityResourceProperty> IdentityResourceProperties { get; set; }
    }
}
