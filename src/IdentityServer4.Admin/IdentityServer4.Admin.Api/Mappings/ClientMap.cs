using IdentityServer4.Admin.Api.Entities;
using IdentityServer4.Admin.Api.Infrastructure.Data;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Api.Mappings
{

    /// <summary>
    /// Clients -- 数据映射
    /// </summary>
    public class ClientMap:ClassMapping<Client>,IEntityMaping
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ClientMap()
        {
            this.Table("Clients");
            // Id
            this.Id(x=>x.Id,map=>{
                map.Generator(Generators.Identity);
            });
 
            // Enabled
            this.Property(x=>x.Enabled,map=>{
                map.NotNullable(true);
            });
 
            // ClientId
            this.Property(x=>x.ClientId,map=>{
                map.NotNullable(true);
                map.Unique(true);
                map.Length(200);
            });
 
            // ProtocolType
            this.Property(x=>x.ProtocolType,map=>{
                map.NotNullable(true);
                map.Length(200);
            });
 
            // RequireClientSecret
            this.Property(x=>x.RequireClientSecret,map=>{
                map.NotNullable(true);
            });
 
            // ClientName
            this.Property(x=>x.ClientName,map=>{
                map.NotNullable(false);
                map.Length(200);
            });
 
            // Description
            this.Property(x=>x.Description,map=>{
                map.NotNullable(false);
                map.Length(1000);
            });
 
            // ClientUri
            this.Property(x=>x.ClientUri,map=>{
                map.NotNullable(false);
                map.Length(2000);
            });
 
            // LogoUri
            this.Property(x=>x.LogoUri,map=>{
                map.NotNullable(false);
                map.Length(2000);
            });
 
            // RequireConsent
            this.Property(x=>x.RequireConsent,map=>{
                map.NotNullable(true);
            });
 
            // AllowRememberConsent
            this.Property(x=>x.AllowRememberConsent,map=>{
                map.NotNullable(true);
            });
 
            // AlwaysIncludeUserClaimsInIdToken
            this.Property(x=>x.AlwaysIncludeUserClaimsInIdToken,map=>{
                map.NotNullable(true);
            });
 
            // RequirePkce
            this.Property(x=>x.RequirePkce,map=>{
                map.NotNullable(true);
            });
 
            // AllowPlainTextPkce
            this.Property(x=>x.AllowPlainTextPkce,map=>{
                map.NotNullable(true);
            });
 
            // AllowAccessTokensViaBrowser
            this.Property(x=>x.AllowAccessTokensViaBrowser,map=>{
                map.NotNullable(true);
            });
 
            // FrontChannelLogoutUri
            this.Property(x=>x.FrontChannelLogoutUri,map=>{
                map.NotNullable(false);
                map.Length(2000);
            });
 
            // FrontChannelLogoutSessionRequired
            this.Property(x=>x.FrontChannelLogoutSessionRequired,map=>{
                map.NotNullable(true);
            });
 
            // BackChannelLogoutUri
            this.Property(x=>x.BackChannelLogoutUri,map=>{
                map.NotNullable(false);
                map.Length(2000);
            });
 
            // BackChannelLogoutSessionRequired
            this.Property(x=>x.BackChannelLogoutSessionRequired,map=>{
                map.NotNullable(true);
            });
 
            // AllowOfflineAccess
            this.Property(x=>x.AllowOfflineAccess,map=>{
                map.NotNullable(true);
            });
 
            // IdentityTokenLifetime
            this.Property(x=>x.IdentityTokenLifetime,map=>{
                map.NotNullable(true);
            });
 
            // AccessTokenLifetime
            this.Property(x=>x.AccessTokenLifetime,map=>{
                map.NotNullable(true);
            });
 
            // AuthorizationCodeLifetime
            this.Property(x=>x.AuthorizationCodeLifetime,map=>{
                map.NotNullable(true);
            });
 
            // ConsentLifetime
            this.Property(x=>x.ConsentLifetime,map=>{
                map.NotNullable(false);
            });
 
            // AbsoluteRefreshTokenLifetime
            this.Property(x=>x.AbsoluteRefreshTokenLifetime,map=>{
                map.NotNullable(true);
            });
 
            // SlidingRefreshTokenLifetime
            this.Property(x=>x.SlidingRefreshTokenLifetime,map=>{
                map.NotNullable(true);
            });
 
            // RefreshTokenUsage
            this.Property(x=>x.RefreshTokenUsage,map=>{
                map.NotNullable(true);
            });
 
            // UpdateAccessTokenClaimsOnRefresh
            this.Property(x=>x.UpdateAccessTokenClaimsOnRefresh,map=>{
                map.NotNullable(true);
            });
 
            // RefreshTokenExpiration
            this.Property(x=>x.RefreshTokenExpiration,map=>{
                map.NotNullable(true);
            });
 
            // AccessTokenType
            this.Property(x=>x.AccessTokenType,map=>{
                map.NotNullable(true);
            });
 
            // EnableLocalLogin
            this.Property(x=>x.EnableLocalLogin,map=>{
                map.NotNullable(true);
            });
 
            // IncludeJwtId
            this.Property(x=>x.IncludeJwtId,map=>{
                map.NotNullable(true);
            });
 
            // AlwaysSendClientClaims
            this.Property(x=>x.AlwaysSendClientClaims,map=>{
                map.NotNullable(true);
            });
 
            // ClientClaimsPrefix
            this.Property(x=>x.ClientClaimsPrefix,map=>{
                map.NotNullable(false);
                map.Length(200);
            });
 
            // PairWiseSubjectSalt
            this.Property(x=>x.PairWiseSubjectSalt,map=>{
                map.NotNullable(false);
                map.Length(200);
            });
 
            // Created
            this.Property(x=>x.Created,map=>{
                map.NotNullable(true);
            });
 
            // Updated
            this.Property(x=>x.Updated,map=>{
                map.NotNullable(false);
            });
 
            // LastAccessed
            this.Property(x=>x.LastAccessed,map=>{
                map.NotNullable(false);
            });
 
            // UserSsoLifetime
            this.Property(x=>x.UserSsoLifetime,map=>{
                map.NotNullable(false);
            });
 
            // UserCodeType
            this.Property(x=>x.UserCodeType,map=>{
                map.NotNullable(false);
                map.Length(100);
            });
 
            // DeviceCodeLifetime
            this.Property(x=>x.DeviceCodeLifetime,map=>{
                map.NotNullable(true);
            });
 
            // NonEditable
            this.Property(x=>x.NonEditable,map=>{
                map.NotNullable(true);
            });
 
        }
    }
}

