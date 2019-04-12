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
    /// ApiResources -- 数据映射
    /// </summary>
    public class ApiResourceMap:ClassMapping<ApiResource>,IEntityMaping
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ApiResourceMap()
        {
            this.Table("ApiResources");
            // Id
            this.Id(x=>x.Id,map=>{
                map.Generator(Generators.Identity);
            });
 
            // Enabled
            this.Property(x=>x.Enabled,map=>{
                map.NotNullable(true);
            });
 
            // Name
            this.Property(x=>x.Name,map=>{
                map.NotNullable(true);
                map.Unique(true);
                map.Length(200);
            });
 
            // DisplayName
            this.Property(x=>x.DisplayName,map=>{
                map.NotNullable(false);
                map.Length(200);
            });
 
            // Description
            this.Property(x=>x.Description,map=>{
                map.NotNullable(false);
                map.Length(1000);
            });
 
            // Created
            this.Property(x=>x.Created,map=>{
                map.NotNullable(true);
            });
 
            // Updated
            this.Property(x=>x.Updated,map=>{
                map.NotNullable(false);
            });
 
            // LastAccessed
            this.Property(x=>x.LastAccessed,map=>{
                map.NotNullable(false);
            });
 
            // NonEditable
            this.Property(x=>x.NonEditable,map=>{
                map.NotNullable(true);
            });
 
        }
    }
}

