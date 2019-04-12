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
    /// IdentityClaims -- 数据映射
    /// </summary>
    public class IdentityClaimMap:ClassMapping<IdentityClaim>,IEntityMaping
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public IdentityClaimMap()
        {
            this.Table("IdentityClaims");
            // Id
            this.Id(x=>x.Id,map=>{
                map.Generator(Generators.Identity);
            });
 
            // Type
            this.Property(x=>x.Type,map=>{
                map.NotNullable(true);
                map.Length(200);
            });
 
            // IdentityResourceId
            this.Property(x=>x.IdentityResourceId,map=>{
                map.NotNullable(true);
            });
 
        }
    }
}

