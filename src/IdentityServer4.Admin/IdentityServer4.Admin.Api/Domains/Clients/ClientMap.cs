using IdentityServer4.Admin.Api.Entities;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Api.Domains.Clients
{
    public class ClientMap : ClassMapping<Client>
    {
        public ClientMap()
        {
            this.Table("Client");
            this.Id(x => x.Id, map => {
                map.Generator(Generators.Identity);
            });

            this.Property(x => x.Enabled, map => {
                map.NotNullable(true);
            });

            this.Property(x => x.ClientId, map => {
                map.NotNullable(true);
                map.Unique(true);
                map.Length(200);
            });

            this.Property(x => x.ProtocolType, map => {
                map.NotNullable(true);
                map.Length(200);
            });

            this.Property(x => x.RequireClientSecret, map => {
                map.NotNullable(true);
            });

            this.Property(x => x.ClientName, map => {
                map.NotNullable(false);
                map.Length(200);
            });

            this.Property(x => x.Description, map => {
                map.NotNullable(false);
                map.Length(1000);
            });

            this.Property(x => x.ClientUri, map => {
                map.NotNullable(false);
                map.Length(2000);
            });

            this.Property(x => x.LogoUri, map => {
                map.NotNullable(false);
                map.Length(2000);
            });

            this.Property(x => x.RequireConsent, map => {
                map.NotNullable(true);
            });

            this.Property(x => x.AllowRememberConsent, map => {
                map.NotNullable(true);
            });

            this.Property(x => x.AlwaysIncludeUserClaimsInIdToken, map => {
                map.NotNullable(true);
            });

            this.Property(x => x.RequirePkce, map => {
                map.NotNullable(true);
            });

            this.Property(x => x.AllowPlainTextPkce, map => {
                map.NotNullable(true);
            });

            this.Property(x => x.AllowAccessTokensViaBrowser, map => {
                map.NotNullable(true);
            });

            this.Property(x => x.FrontChannelLogoutUri, map => {
                map.NotNullable(false);
                map.Length(2000);
            });

            this.Property(x => x.FrontChannelLogoutSessionRequired, map => {
                map.NotNullable(true);
            });

            this.Property(x => x.BackChannelLogoutUri, map => {
                map.NotNullable(false);
                map.Length(2000);
            });

            this.Property(x => x.BackChannelLogoutSessionRequired, map => {
                map.NotNullable(true);
            });

            this.Property(x => x.AllowOfflineAccess, map => {
                map.NotNullable(true);
            });

            this.Property(x => x.IdentityTokenLifetime, map => {
                map.NotNullable(true);
            });

            this.Property(x => x.AccessTokenLifetime, map => {
                map.NotNullable(true);
            });

            this.Property(x => x.AuthorizationCodeLifetime, map => {
                map.NotNullable(true);
            });

            this.Property(x => x.ConsentLifetime, map => {
                map.NotNullable(false);
            });

            this.Property(x => x.AbsoluteRefreshTokenLifetime, map => {
                map.NotNullable(true);
            });

            this.Property(x => x.SlidingRefreshTokenLifetime, map => {
                map.NotNullable(true);
            });

            this.Property(x => x.RefreshTokenUsage, map => {
                map.NotNullable(true);
            });

            this.Property(x => x.UpdateAccessTokenClaimsOnRefresh, map => {
                map.NotNullable(true);
            });

            this.Property(x => x.RefreshTokenExpiration, map => {
                map.NotNullable(true);
            });

            this.Property(x => x.AccessTokenType, map => {
                map.NotNullable(true);
            });

            this.Property(x => x.EnableLocalLogin, map => {
                map.NotNullable(true);
            });

            this.Property(x => x.IncludeJwtId, map => {
                map.NotNullable(true);
            });

            this.Property(x => x.AlwaysSendClientClaims, map => {
                map.NotNullable(true);
            });

            this.Property(x => x.ClientClaimsPrefix, map => {
                map.NotNullable(false);
                map.Length(200);
            });

            this.Property(x => x.PairWiseSubjectSalt, map => {
                map.NotNullable(false);
                map.Length(200);
            });

            this.Property(x => x.Created, map => {
                map.NotNullable(true);
            });

            this.Property(x => x.Updated, map => {
                map.NotNullable(false);
            });

            this.Property(x => x.LastAccessed, map => {
                map.NotNullable(false);
            });

            this.Property(x => x.UserSsoLifetime, map => {
                map.NotNullable(false);
            });

            this.Property(x => x.UserCodeType, map => {
                map.NotNullable(false);
                map.Length(100);
            });

            this.Property(x => x.DeviceCodeLifetime, map => {
                map.NotNullable(true);
            });

            this.Property(x => x.NonEditable, map => {
                map.NotNullable(true);
            });

        }
    }
}
