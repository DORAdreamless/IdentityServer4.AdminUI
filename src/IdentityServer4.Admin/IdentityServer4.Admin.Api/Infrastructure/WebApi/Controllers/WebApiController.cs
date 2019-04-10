using IdentityServer4.Admin.Api.Infrastructure.WebApi.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Api.Infrastructure.WebApi.Controllers
{
    [ApiController]
    [WebApiExceptionFilter]
    [Authorize]
    public class WebApiController : ControllerBase
    {
        protected IActionResult Success(object data = null, string message = "", int code = 200)
        {
            return new JsonResult(new { success = true, data, message, code });
        }

        protected IActionResult Fail(string message, object data = null, int code = 400)
        {
            return new JsonResult(new { success = false, data, message, code });
        }
    }
}
