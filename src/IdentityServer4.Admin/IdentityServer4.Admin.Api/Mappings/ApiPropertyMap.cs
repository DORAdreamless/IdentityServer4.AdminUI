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
    /// ApiProperties -- 数据映射
    /// </summary>
    public class ApiPropertyMap:ClassMapping<ApiProperty>,IEntityMaping
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ApiPropertyMap()
        {
            this.Table("ApiProperties");
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
 
            // ApiResourceId
            this.Property(x=>x.ApiResourceId,map=>{
                map.NotNullable(true);
            });
 
        }
    }
}

