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
    /// PersistedGrants -- 数据映射
    /// </summary>
    public class PersistedGrantMap:ClassMapping<PersistedGrant>,IEntityMaping
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public PersistedGrantMap()
        {
            this.Table("PersistedGrants");
            // Key
            this.Id(x=>x.Key,map=>{
                map.Generator(Generators.Native);
                map.Length(200);
            });
 
            // Type
            this.Property(x=>x.Type,map=>{
                map.NotNullable(true);
                map.Length(50);
            });
 
            // SubjectId
            this.Property(x=>x.SubjectId,map=>{
                map.NotNullable(false);
                map.Length(200);
            });
 
            // ClientId
            this.Property(x=>x.ClientId,map=>{
                map.NotNullable(true);
                map.Length(200);
            });
 
            // CreationTime
            this.Property(x=>x.CreationTime,map=>{
                map.NotNullable(true);
            });
 
            // Expiration
            this.Property(x=>x.Expiration,map=>{
                map.NotNullable(false);
            });
 
            // Data
            this.Property(x=>x.Data,map=>{
                map.NotNullable(true);
                map.Length(8000);
            });
 
        }
    }
}

