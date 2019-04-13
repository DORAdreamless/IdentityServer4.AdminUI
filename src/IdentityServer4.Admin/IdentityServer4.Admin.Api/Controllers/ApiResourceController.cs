using IdentityServer4.Admin.Api.Dtos.Configuration;
using IdentityServer4.Admin.Api.Infrastructure.UI;
using IdentityServer4.Admin.Api.Infrastructure.WebApi.Controllers;
using IdentityServer4.Admin.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using IdentityServer4.Admin.Api.Dtos.Requests;
using IdentityServer4.Admin.Api.Entities;

namespace IdentityServer4.Admin.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    //[Authorize(Roles="admin")]
    public class ApiResourceController: WebApiController
    {
        private readonly ApiResourceService service;

        public ApiResourceController(ApiResourceService service)
        {
            this.service = service;
        }

        #region ApiResource

        [HttpPost]
        [Route("/api/IdentityServer/ApiResource/GetApiResourceByPage")]
        public IActionResult GetApiResourceByPage([FromBody]ApiResourcePageRequest pageRequest)
        {
            PageList<ApiResourceListDto> data = this.service.GetRecordByPage<ApiResource,ApiResourceListDto>(pageRequest);
            return Success(data);
        }
        [HttpGet]
        [Route("/api/IdentityServer/ApiResource/GetApiResource")]
        public IActionResult GetApiResource(int? id)
        {
            ApiResourceDto data = this.service.GetApiResourceDto(id);
            return Success(data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ApiResourceDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/IdentityServer/ApiResource/AddApiResource")]
        public IActionResult AddApiResource([FromBody]ApiResourceDto ApiResourceDto)
        {
            this.service.AddApiResource(ApiResourceDto);
            return Success();
        }
        [HttpPost]
        [Route("/api/IdentityServer/ApiResource/UpdateApiResource")]
        public IActionResult UpdateApiResource(int id, [FromBody]ApiResourceDto ApiResourceDto)
        {
            this.service.UpdateApiResource(id, ApiResourceDto);
            return Success();
        }
        /// <summary>
        /// 删除客户端
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/IdentityServer/ApiResource/DeleteApiResource")]
        public IActionResult DeleteApiResource(int id)
        {
            this.service.DeleteApiResource(id);
            return Success();
        }
        #endregion
        #region ApiScope

        [HttpGet]
        [Route("/api/IdentityServer/ApiScope/GetApiScopes")]
        public IActionResult GetApiScopes(int apiResourceId)
        {
            List<ApiScopeListDto> data = this.service.GetApiScopes(apiResourceId);
            return Success(data);
        }
        [HttpGet]
        [Route("/api/IdentityServer/ApiScope/GetApiScope")]
        public IActionResult GetApiScope(int? id)
        {
            ApiScopeDto data = this.service.GetApiScopeDto(id);
            return Success(data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ApiScopeDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/IdentityServer/ApiScope/AddApiScope")]
        public IActionResult AddApiScope([FromBody]ApiScopeDto ApiScopeDto)
        {
            this.service.AddApiScope(ApiScopeDto);
            return Success();
        }
        [HttpPost]
        [Route("/api/IdentityServer/ApiScope/UpdateApiScope")]
        public IActionResult UpdateApiScope(int id, [FromBody]ApiScopeDto ApiScopeDto)
        {
            this.service.UpdateApiScope(id, ApiScopeDto);
            return Success();
        }
        /// <summary>
        /// 删除客户端
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/IdentityServer/ApiScope/DeleteApiScope")]
        public IActionResult DeleteApiScope(int id)
        {
            this.service.DeleteApiScope(id);
            return Success();
        }
        #endregion
        #region ApiProperty
        [HttpGet]
        [Route("/api/IdentityServer/ApiProperty/GetApiProperties")]
        public IActionResult GetApiProperties(int apiResourceId)
        {
            List<ApiPropertyListDto> data = this.service.GetApiProperties(apiResourceId);
            return Success(data);
        }
        [HttpGet]
        [Route("/api/IdentityServer/ApiProperty/GetApiProperty")]
        public IActionResult GetApiProperty(int? id)
        {
            ApiPropertyDto data = this.service.GetApiProperty(id);
            return Success(data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiPropertyDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/IdentityServer/ApiProperty/AddApiProperty")]
        public IActionResult AddApiProperty([FromBody]ApiPropertyDto apiPropertyDto)
        {
            this.service.AddApiProperty(apiPropertyDto);
            return Success();
        }
        [HttpPost]
        [Route("/api/IdentityServer/ApiProperty/UpdateApiProperty")]
        public IActionResult UpdateApiProperty(int id, [FromBody]ApiPropertyDto apiPropertyDto)
        {
            this.service.UpdateApiProperty(id, apiPropertyDto);
            return Success();
        }
        /// <summary>
        /// 删除客户端
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/IdentityServer/ApiProperty/DeleteApiProperty")]
        public IActionResult DeleteApiProperty(int id)
        {
            this.service.DeleteApiProperty(id);
            return Success();
        }
        #endregion
        #region ApiSecret
        [HttpGet]
        [Route("/api/IdentityServer/ApiSecret/GetApiSecrets")]
        public IActionResult GetApiSecrets(int apiResourceId)
        {
            List<ApiSecretListDto> data = this.service.GetApiSecrets(apiResourceId);
            return Success(data);
        }
        [HttpGet]
        [Route("/api/IdentityServer/ApiSecret/GetApiSecret")]
        public IActionResult GetApiSecret(int? id)
        {
            ApiSecretDto data = this.service.GetApiSecret(id);
            return Success(data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiSecretDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/IdentityServer/ApiSecret/AddApiSecret")]
        public IActionResult AddApiSecret([FromBody]ApiSecretDto apiSecretDto)
        {
            this.service.AddApiSecret(apiSecretDto);
            return Success();
        }
        [HttpPost]
        [Route("/api/IdentityServer/ApiSecret/UpdateApiSecret")]
        public IActionResult UpdateApiSecret(int id, [FromBody]ApiSecretDto apiSecretDto)
        {
            this.service.UpdateApiSecret(id, apiSecretDto);
            return Success();
        }
        /// <summary>
        /// 删除客户端
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/IdentityServer/ApiSecret/DeleteApiSecret")]
        public IActionResult DeleteApiSecret(int id)
        {
            this.service.DeleteApiSecret(id);
            return Success();
        }
        #endregion
    }
}
