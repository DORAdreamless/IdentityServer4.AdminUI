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
    /// ClientSecrets -- 数据映射
    /// </summary>
    public class ClientSecretMap:ClassMapping<ClientSecret>,IEntityMaping
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ClientSecretMap()
        {
            this.Table("ClientSecrets");
            // Id
            this.Id(x=>x.Id,map=>{
                map.Generator(Generators.Identity);
            });
 
            // Description
            this.Property(x=>x.Description,map=>{
                map.NotNullable(false);
                map.Length(2000);
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
 
            // ClientId
            this.Property(x=>x.ClientId,map=>{
                map.NotNullable(true);
            });
 
        }
    }
}

