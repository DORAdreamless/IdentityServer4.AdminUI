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
    /// ClientIdPRestrictions -- 数据映射
    /// </summary>
    public class ClientIdPRestrictionMap:ClassMapping<ClientIdPRestriction>,IEntityMaping
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ClientIdPRestrictionMap()
        {
            this.Table("ClientIdPRestrictions");
            // Id
            this.Id(x=>x.Id,map=>{
                map.Generator(Generators.Identity);
            });
 
            // Provider
            this.Property(x=>x.Provider,map=>{
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

