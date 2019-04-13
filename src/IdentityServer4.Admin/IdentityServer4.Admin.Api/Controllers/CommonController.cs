using IdentityServer4.Admin.Api.Infrastructure.WebApi.Controllers;
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

        public CommonController(IHostingEnvironment environment)
        {
            this.environment = environment;
        }

        public IActionResult Upload(string category="others")
        {
           string relativePath = string.Format("");
           string filePath= System.IO.Path.Combine(this.environment.WebRootPath, "statics", category);
           
            return Success();
        }
    }
}
