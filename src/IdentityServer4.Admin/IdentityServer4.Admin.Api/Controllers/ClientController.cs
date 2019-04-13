using FluentValidation.AspNetCore;
using IdentityServer4.Admin.Api.Dtos.Configuration;
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
   // [Authorize(Roles = "admin")]
    public class ClientController: WebApiController
    {
        /// <summary>
        /// ClientService
        /// </summary>
        private readonly ClientService service;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="service"></param>
        public ClientController(ClientService service)
        {
            this.service = service;
        }

        #region 客户端


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        [HttpGet]
        [Route("/api/IdentityServer/Client/GetClient")]
        public IActionResult GetClient(int? id)
        {
            ClientDto clientDto = this.service.GetClient(id);
            return Success(clientDto);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("/api/IdentityServer/Client/AddClient")]
        public IActionResult AddClient([FromBody][CustomizeValidator(RuleSet ="name")]ClientDto clientDto)
        {
            this.service.AddClient(clientDto);
            return Success();
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("/api/IdentityServer/client/name")]
        public IActionResult UpdateClientName(int id,[FromBody][CustomizeValidator(RuleSet = "name")]ClientDto model)
        {
            return Success();
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("/api/IdentityServer/client/basic")]
        public IActionResult UpdateClientBasic(int id,[FromBody][CustomizeValidator(RuleSet = "basic")]ClientDto model)
        {
            return Success();
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("/api/IdentityServer/client/authorization")]
        public IActionResult UpdateClientAuthorization(int id, [FromBody][CustomizeValidator(RuleSet = "authorization")]ClientDto model)
        {
            return Success();
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("/api/IdentityServer/client/token")]
        public IActionResult UpdateClientToken(int id, [FromBody][CustomizeValidator(RuleSet = "token")]ClientDto model)
        {
            return Success();
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("/api/IdentityServer/client/device_flow")]
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
        [Route("/api/IdentityServer/client")]
        public IActionResult DeleteClient(int id)
        {
            return Success();
        }
        #endregion


    }
}
