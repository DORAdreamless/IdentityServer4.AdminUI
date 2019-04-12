using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Api.Entities
{
   public class DeviceCode
    {
        /// <summary>
        /// DeviceCode
        /// </summary>
        public virtual String deviceCode { get; set; }
        /// <summary>
        /// UserCode
        /// </summary>
        public virtual String UserCode { get; set; }
        /// <summary>
        /// SubjectId
        /// </summary>
        public virtual String SubjectId { get; set; }
        /// <summary>
        /// ClientId
        /// </summary>
        public virtual String ClientId { get; set; }
        /// <summary>
        /// CreationTime
        /// </summary>
        public virtual DateTime CreationTime { get; set; }
        /// <summary>
        /// Expiration
        /// </summary>
        public virtual DateTime Expiration { get; set; }
        /// <summary>
        /// Data
        /// </summary>
        public virtual String Data { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        public DeviceCode()
        {
            deviceCode = string.Empty;
            UserCode = string.Empty;
            SubjectId = string.Empty;
            ClientId = string.Empty;
            CreationTime = DateTime.Now;
            Expiration = DateTime.Now;
            Data = string.Empty;
        }
    }
}
