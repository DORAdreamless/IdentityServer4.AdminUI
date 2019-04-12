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
    /// ApiSecrets -- 数据映射
    /// </summary>
    public class ApiSecretMap:ClassMapping<ApiSecret>,IEntityMaping
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ApiSecretMap()
        {
            this.Table("ApiSecrets");
            // Id
            this.Id(x=>x.Id,map=>{
                map.Generator(Generators.Identity);
            });
 
            // Description
            this.Property(x=>x.Description,map=>{
                map.NotNullable(false);
                map.Length(1000);
            });
 
            // Value
            this.Property(x=>x.Value,map=>{
                map.NotNullable(true);
                map.Length(4000);
            });
 
            // Expiration
            this.Property(x=>x.Expiration,map=>{
                map.NotNullable(false);
            });
 
            // Type
            this.Property(x=>x.Type,map=>{
                map.NotNullable(true);
                map.Length(250);
            });
 
            // Created
            this.Property(x=>x.Created,map=>{
                map.NotNullable(true);
            });
 
            // ApiResourceId
            this.Property(x=>x.ApiResourceId,map=>{
                map.NotNullable(true);
            });
 
        }
    }
}

