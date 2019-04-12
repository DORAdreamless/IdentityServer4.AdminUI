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
    /// DeviceCodes -- 数据映射
    /// </summary>
    public class DeviceCodeMap:ClassMapping<DeviceCode>,IEntityMaping
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public DeviceCodeMap()
        {
            this.Table("DeviceCodes");
            // UserCode
            this.Id(x=>x.UserCode,map=>{
                map.Generator(Generators.Native);
                map.Length(200);
            });
 
            // DeviceCode
            this.Property(x=>x.deviceCode,map=>{
                map.NotNullable(true);
                map.Unique(true);
                map.Length(200);
                map.Column("DeviceCode");
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
                map.NotNullable(true);
            });
 
            // Data
            this.Property(x=>x.Data,map=>{
                map.NotNullable(true);
                map.Length(8000);
            });
 
        }
    }
}

