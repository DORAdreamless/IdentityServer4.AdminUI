using IdentityServer4.Admin.Api.Infrastructure.WebApi.Controllers;
using IdentityServer4.Admin.Api.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Api.Controllers
{
   public class CommonController:WebApiController
    {
        private readonly IHostingEnvironment environment;

        private readonly DefaultStoreService service;
        public CommonController(IHostingEnvironment environment, DefaultStoreService service)
        {
            this.environment = environment;
            this.service = service;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/common/upload")]
        public IActionResult Upload()
        {
            if (Request.HasFormContentType)
            {
                return Success(service.SaveFileIfExist("File"));
            }
            return Fail("请上传文件！");
        }
    }
}
