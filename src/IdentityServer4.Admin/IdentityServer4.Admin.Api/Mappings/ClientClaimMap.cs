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
    /// ClientClaims -- 数据映射
    /// </summary>
    public class ClientClaimMap:ClassMapping<ClientClaim>,IEntityMaping
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ClientClaimMap()
        {
            this.Table("ClientClaims");
            // Id
            this.Id(x=>x.Id,map=>{
                map.Generator(Generators.Identity);
            });
 
            // Type
            this.Property(x=>x.Type,map=>{
                map.NotNullable(true);
                map.Length(250);
            });
 
            // Value
            this.Property(x=>x.Value,map=>{
                map.NotNullable(true);
                map.Length(250);
            });
 
            // ClientId
            this.Property(x=>x.ClientId,map=>{
                map.NotNullable(true);
            });
 
        }
    }
}

