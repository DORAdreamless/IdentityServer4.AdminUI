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
    /// ClientGrantTypes -- 数据映射
    /// </summary>
    public class ClientGrantTypeMap:ClassMapping<ClientGrantType>,IEntityMaping
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ClientGrantTypeMap()
        {
            this.Table("ClientGrantTypes");
            // Id
            this.Id(x=>x.Id,map=>{
                map.Generator(Generators.Identity);
            });
 
            // GrantType
            this.Property(x=>x.GrantType,map=>{
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

