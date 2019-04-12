using IdentityServer4.Admin.Api.Dtos.Configuration;
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
   
    public class IdentityResourceController : WebApiController
    {
        private readonly IdentityResourceService service;

        public IdentityResourceController(IdentityResourceService service)
        {
            this.service = service;
        }
        #region IdentityResource

        [HttpPost]
        [Route("/api/IdentityServer/IdentityResource/GetIdentityResourceByPage")]
        public IActionResult GetIdentityResourceByPage([FromBody]PageRequest pageRequest)
        {
            PageList<IdentityResourceDto> data = this.service.GetIdentityResourceByPage(pageRequest);
            return Success(data);
        }
        [HttpGet]
        [Route("/api/IdentityServer/IdentityResource/GetIdentityResource")]
        public IActionResult GetIdentityResource(int? id)
        {
            IdentityResourceDto data = this.service.GetIdentityResourceDto(id);
            return Success(data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="identityResourceDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/IdentityServer/IdentityResource/AddIdentityResource")]
        public IActionResult AddIdentityResource([FromBody]IdentityResourceDto identityResourceDto)
        {
            this.service.AddIdentityResource(identityResourceDto);
            return Success();
        }
        [HttpPost]
        [Route("/api/IdentityServer/IdentityResource/UpdateIdentityResource")]
        public IActionResult UpdateIdentityResource(int id,[FromBody]IdentityResourceDto identityResourceDto)
        {
            this.service.UpdateIdentityResource(id,identityResourceDto);
            return Success();
        }
        /// <summary>
        /// 删除客户端
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/IdentityServer/IdentityResource/DeleteIdentityResource")]
        public IActionResult DeleteIdentityResource(int id)
        {
            this.service.DeleteIdentityResource(id);
            return Success();
        }
        #endregion

        #region IdentityProperty
        [HttpGet]
        [Route("/api/IdentityServer/IdentityProperty/GetIdentityProperties")]
        public IActionResult GetIdentityProperties(int identityResourceId)
        {
            List<IdentityPropertyDto> data = this.service.GetIdentityProperties(identityResourceId);
            return Success(data);
        }
        [HttpGet]
        [Route("/api/IdentityServer/IdentityProperty/IdentityProperty")]
        public IActionResult GetIdentityProperty(int? id)
        {
            IdentityPropertyDto data = this.service.GetIdentityProperty(id);
            return Success(data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="identityResourcePropertyDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/IdentityServer/IdentityProperty/AddIdentityProperty")]
        public IActionResult AddIdentityProperty([FromBody]IdentityPropertyDto identityResourcePropertyDto)
        {
            this.service.AddIdentityProperty(identityResourcePropertyDto);
            return Success();
        }
        [HttpPost]
        [Route("/api/IdentityServer/IdentityProperty/UpdateIdentityProperty")]
        public IActionResult UpdateIdentityProperty(int id, [FromBody]IdentityPropertyDto IdentityResourcePropertyDto)
        {
            this.service.UpdateIdentityProperty(id, IdentityResourcePropertyDto);
            return Success();
        }
        /// <summary>
        /// 删除客户端
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/IdentityServer/IdentityProperty/DeleteIdentityProperty")]
        public IActionResult DeleteIdentityProperty(int id)
        {
            this.service.DeleteIdentityProperty(id);
            return Success();
        }
        #endregion
    }
}
