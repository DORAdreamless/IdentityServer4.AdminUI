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
    /// ApiScopeClaims -- 数据映射
    /// </summary>
    public class ApiScopeClaimMap:ClassMapping<ApiScopeClaim>,IEntityMaping
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ApiScopeClaimMap()
        {
            this.Table("ApiScopeClaims");
            // Id
            this.Id(x=>x.Id,map=>{
                map.Generator(Generators.Identity);
            });
 
            // Type
            this.Property(x=>x.Type,map=>{
                map.NotNullable(true);
                map.Length(200);
            });
 
            // ApiScopeId
            this.Property(x=>x.ApiScopeId,map=>{
                map.NotNullable(true);
            });
 
        }
    }
}

