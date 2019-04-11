using FluentValidation.AspNetCore;
using IdentityServer4.Admin.Api.Domains.Clients;
using IdentityServer4.Admin.Api.Infrastructure.WebApi.Controllers;
using IdentityServer4.Admin.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize(Roles = "admin")]
    public class ConfigurationController: WebApiController
    {
        /// <summary>
        /// ClientService
        /// </summary>
        private readonly ClientService clientService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="clientService"></param>
        public ConfigurationController(ClientService clientService)
        {
            this.clientService = clientService;
        }

        #region 客户端


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        [HttpGet]
        [Route("/api/Configuration/client")]
        public void Client(int? id)
        {

        }

        [HttpPost]
        [AllowAnonymous]
        [Route("/api/Configuration/client/create")]
        public IActionResult CreateClient([FromBody][CustomizeValidator(RuleSet ="name")]ClientDto model)
        {
            this.clientService.CreateClient(model);
            return Success();
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("/api/Configuration/client/name")]
        public IActionResult UpdateClientName(int id,[FromBody][CustomizeValidator(RuleSet = "name")]ClientDto model)
        {
            return Success();
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("/api/Configuration/client/basic")]
        public IActionResult UpdateClientBasic(int id,[FromBody][CustomizeValidator(RuleSet = "basic")]ClientDto model)
        {
            return Success();
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("/api/configuration/client/authorization")]
        public IActionResult UpdateClientAuthorization(int id, [FromBody][CustomizeValidator(RuleSet = "authorization")]ClientDto model)
        {
            return Success();
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("/api/Configuration/client/token")]
        public IActionResult UpdateClientToken(int id, [FromBody][CustomizeValidator(RuleSet = "token")]ClientDto model)
        {
            return Success();
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("/api/Configuration/client/device_flow")]
        public IActionResult UpdateClientDeviceFlow(int id, [FromBody][CustomizeValidator(RuleSet = "device_flow")]ClientDto model)
        {
            return Success();
        }
        /// <summary>
        /// 删除客户端
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/Configuration/client")]
        public IActionResult DeleteClient(int id)
        {
            return Success();
        }
        #endregion
    }
}
