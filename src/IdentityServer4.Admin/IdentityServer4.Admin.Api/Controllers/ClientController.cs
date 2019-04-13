using FluentValidation.AspNetCore;
using IdentityServer4.Admin.Api.Dtos.Configuration;
using IdentityServer4.Admin.Api.Dtos.Requests;
using IdentityServer4.Admin.Api.Entities;
using IdentityServer4.Admin.Api.Infrastructure.UI;
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

        [HttpPost]
        [Route("/api/IdentityServer/Client/GetClientByPage")]
        public IActionResult GetClientByPage([FromBody]ClientPageRequest pageRequest)
        {
            PageList< ClientListDto> clientDto = this.service.GetRecordByPage<Client,ClientListDto>(pageRequest);
            return Success(clientDto);
        }
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
        [Route("/api/IdentityServer/Client/UpdateClientName")]
        public IActionResult UpdateClientName(int id,[FromBody][CustomizeValidator(RuleSet = "name")]ClientDto clientDto)
        {
            this.service.UpdateClientName(id, clientDto);
            return Success();
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("/api/IdentityServer/Client/UpdateClientConsent")]
        public IActionResult UpdateClientConsent(int id, [FromBody][CustomizeValidator(RuleSet = "name")]ClientDto clientDto)
        {
            this.service.UpdateClientConsent(id, clientDto);
            return Success();
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("/api/IdentityServer/Client/UpdateClientBasic")]
        public IActionResult UpdateClientBasic(int id,[FromBody][CustomizeValidator(RuleSet = "basic")]ClientDto clientDto)
        {
            this.service.UpdateClientBasic(id, clientDto);
            return Success();
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("/api/IdentityServer/Client/UpdateClientAuthorization")]
        public IActionResult UpdateClientAuthorization(int id, [FromBody][CustomizeValidator(RuleSet = "authorization")]ClientDto clientDto)
        {
            this.service.UpdateClientAuthorization(id, clientDto);
            return Success();
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("/api/IdentityServer/Client/UpdateClientToken")]
        public IActionResult UpdateClientToken(int id, [FromBody][CustomizeValidator(RuleSet = "token")]ClientDto clientDto)
        {
            this.service.UpdateClientToken(id, clientDto);
            return Success();
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("/api/IdentityServer/Client/UpdateClientDeviceFlow")]
        public IActionResult UpdateClientDeviceFlow(int id, [FromBody][CustomizeValidator(RuleSet = "device_flow")]ClientDto clientDto)
        {
            this.service.UpdateClientDeviceFlow(id, clientDto);
            return Success();
        }
        /// <summary>
        /// 删除客户端
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/IdentityServer/Client/DeleteClient")]
        public IActionResult DeleteClient(int id)
        {
            this.service.DeleteClient(id);
            return Success();
        }
        #endregion


    }
}
