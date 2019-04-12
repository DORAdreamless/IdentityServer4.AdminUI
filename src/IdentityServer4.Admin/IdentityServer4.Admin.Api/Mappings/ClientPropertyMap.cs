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
    /// ClientProperties -- 数据映射
    /// </summary>
    public class ClientPropertyMap:ClassMapping<ClientProperty>,IEntityMaping
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ClientPropertyMap()
        {
            this.Table("ClientProperties");
            // Id
            this.Id(x=>x.Id,map=>{
                map.Generator(Generators.Identity);
            });
 
            // Key
            this.Property(x=>x.Key,map=>{
                map.NotNullable(true);
                map.Length(250);
            });
 
            // Value
            this.Property(x=>x.Value,map=>{
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

