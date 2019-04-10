using IdentityServer4.Admin.Api.Domains.Clients;
using IdentityServer4.Admin.Api.Infrastructure.WebApi.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Api.Controllers
{
   public class ConfigurationController: WebApiController
    {
        [HttpGet]
        [Route("/api/Configuration/client")]
        public void Client(int? id)
        {

        }

        [HttpPost]
        [AllowAnonymous]
        [Route("/api/Configuration/client/create")]
        public IActionResult CreateClient([FromBody]CreateClientModel model)
        {
            return Success();
        }
    }
}
