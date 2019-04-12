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
    /// ClientCorsOrigins -- 数据映射
    /// </summary>
    public class ClientCorsOriginMap:ClassMapping<ClientCorsOrigin>,IEntityMaping
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ClientCorsOriginMap()
        {
            this.Table("ClientCorsOrigins");
            // Id
            this.Id(x=>x.Id,map=>{
                map.Generator(Generators.Identity);
            });
 
            // Origin
            this.Property(x=>x.Origin,map=>{
                map.NotNullable(true);
                map.Length(150);
            });
 
            // ClientId
            this.Property(x=>x.ClientId,map=>{
                map.NotNullable(true);
            });
 
        }
    }
}

