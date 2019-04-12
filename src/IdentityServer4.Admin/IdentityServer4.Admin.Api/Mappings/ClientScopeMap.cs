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
    /// ClientScopes -- 数据映射
    /// </summary>
    public class ClientScopeMap:ClassMapping<ClientScope>,IEntityMaping
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ClientScopeMap()
        {
            this.Table("ClientScopes");
            // Id
            this.Id(x=>x.Id,map=>{
                map.Generator(Generators.Identity);
            });
 
            // Scope
            this.Property(x=>x.Scope,map=>{
                map.NotNullable(true);
                map.Length(200);
            });
 
            // ClientId
            this.Property(x=>x.ClientId,map=>{
                map.NotNullable(true);
            });
 
        }
    }
}

