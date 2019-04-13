using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Exceptionless.Extensions;

namespace IdentityServer4.Admin.Api.Infrastructure.WebApi.Filters
{
    public class WebApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            Exception ex=context.Exception.GetInnermostException();
            context.Result = new JsonResult(new { success=false,message=ex.Message,data=new object(),code=500 });
        }
    }
}
