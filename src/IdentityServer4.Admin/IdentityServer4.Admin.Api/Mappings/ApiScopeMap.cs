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
    /// ApiScopes -- 数据映射
    /// </summary>
    public class ApiScopeMap:ClassMapping<ApiScope>,IEntityMaping
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ApiScopeMap()
        {
            this.Table("ApiScopes");
            // Id
            this.Id(x=>x.Id,map=>{
                map.Generator(Generators.Identity);
            });
 
            // Name
            this.Property(x=>x.Name,map=>{
                map.NotNullable(true);
                map.Unique(true);
                map.Length(200);
            });
 
            // DisplayName
            this.Property(x=>x.DisplayName,map=>{
                map.NotNullable(false);
                map.Length(200);
            });
 
            // Description
            this.Property(x=>x.Description,map=>{
                map.NotNullable(false);
                map.Length(1000);
            });
 
            // Required
            this.Property(x=>x.Required,map=>{
                map.NotNullable(true);
            });
 
            // Emphasize
            this.Property(x=>x.Emphasize,map=>{
                map.NotNullable(true);
            });
 
            // ShowInDiscoveryDocument
            this.Property(x=>x.ShowInDiscoveryDocument,map=>{
                map.NotNullable(true);
            });
 
            // ApiResourceId
            this.Property(x=>x.ApiResourceId,map=>{
                map.NotNullable(true);
            });
 
        }
    }
}

