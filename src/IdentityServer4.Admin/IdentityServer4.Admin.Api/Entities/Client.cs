// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


#pragma warning disable 1591

using IdentityServer4.Models;
using System;
using System.Collections.Generic;

namespace IdentityServer4.Admin.Api.Entities
{
    public  class Client
    {
        public virtual  int Id { get; set; }
        public virtual  bool Enabled { get; set; } = true;
        public virtual  string ClientId { get; set; }
        public virtual  string ProtocolType { get; set; } = "oidc";
        public virtual  List<ClientSecret> ClientSecrets { get; set; }
        public virtual  bool RequireClientSecret { get; set; } = true;
        public virtual  string ClientName { get; set; }
        public virtual  string Description { get; set; }
        public virtual  string ClientUri { get; set; }
        public virtual  string LogoUri { get; set; }
        public virtual  bool RequireConsent { get; set; } = true;
        public virtual  bool AllowRememberConsent { get; set; } = true;
        public virtual  bool AlwaysIncludeUserClaimsInIdToken { get; set; }
        public virtual  List<ClientGrantType> AllowedGrantTypes { get; set; }
        public virtual  bool RequirePkce { get; set; }
        public virtual  bool AllowPlainTextPkce { get; set; }
        public virtual  bool AllowAccessTokensViaBrowser { get; set; }
        public virtual  List<ClientRedirectUri> RedirectUris { get; set; }
        public virtual  List<ClientPostLogoutRedirectUri> PostLogoutRedirectUris { get; set; }
        public virtual  string FrontChannelLogoutUri { get; set; }
        public virtual  bool FrontChannelLogoutSessionRequired { get; set; } = true;
        public virtual  string BackChannelLogoutUri { get; set; }
        public virtual  bool BackChannelLogoutSessionRequired { get; set; } = true;
        public virtual  bool AllowOfflineAccess { get; set; }
        public virtual  List<ClientScope> AllowedScopes { get; set; }
        public virtual  int IdentityTokenLifetime { get; set; } = 300;
        public virtual  int AccessTokenLifetime { get; set; } = 3600;
        public virtual  int AuthorizationCodeLifetime { get; set; } = 300;
        public virtual  int? ConsentLifetime { get; set; } = null;
        public virtual  int AbsoluteRefreshTokenLifetime { get; set; } = 2592000;
        public virtual  int SlidingRefreshTokenLifetime { get; set; } = 1296000;
        public virtual  int RefreshTokenUsage { get; set; } = (int)TokenUsage.OneTimeOnly;
        public virtual  bool UpdateAccessTokenClaimsOnRefresh { get; set; }
        public virtual  int RefreshTokenExpiration { get; set; } = (int)TokenExpiration.Absolute;
        public virtual  int AccessTokenType { get; set; } = (int)0; // AccessTokenType.Jwt;
        public virtual  bool EnableLocalLogin { get; set; } = true;
        public virtual  List<ClientIdPRestriction> IdentityProviderRestrictions { get; set; }
        public virtual  bool IncludeJwtId { get; set; }
        public virtual  List<ClientClaim> Claims { get; set; }
        public virtual  bool AlwaysSendClientClaims { get; set; }
        public virtual  string ClientClaimsPrefix { get; set; } = "client_";
        public virtual  string PairWiseSubjectSalt { get; set; }
        public virtual  List<ClientCorsOrigin> AllowedCorsOrigins { get; set; }
        public virtual  List<ClientProperty> Properties { get; set; }
        public virtual  DateTime Created { get; set; } = DateTime.UtcNow;
        public virtual  DateTime? Updated { get; set; }
        public virtual  DateTime? LastAccessed { get; set; }
        public virtual  int? UserSsoLifetime { get; set; }
        public virtual  string UserCodeType { get; set; }
        public virtual  int DeviceCodeLifetime { get; set; } = 300;
        public virtual  bool NonEditable { get; set; }
    }
}