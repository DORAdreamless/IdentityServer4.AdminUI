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
    /// ClientPostLogoutRedirectUris -- 数据映射
    /// </summary>
    public class ClientPostLogoutRedirectUriMap:ClassMapping<ClientPostLogoutRedirectUri>,IEntityMaping
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ClientPostLogoutRedirectUriMap()
        {
            this.Table("ClientPostLogoutRedirectUris");
            // Id
            this.Id(x=>x.Id,map=>{
                map.Generator(Generators.Identity);
            });
 
            // PostLogoutRedirectUri
            this.Property(x=>x.PostLogoutRedirectUri,map=>{
                map.NotNullable(true);
                map.Length(2000);
            });
 
            // ClientId
            this.Property(x=>x.ClientId,map=>{
                map.NotNullable(true);
            });
 
        }
    }
}

