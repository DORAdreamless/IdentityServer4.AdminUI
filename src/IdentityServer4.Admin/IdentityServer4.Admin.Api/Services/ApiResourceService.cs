using IdentityServer4.Admin.Api.Dtos.Configuration;
using IdentityServer4.Admin.Api.Entities;
using IdentityServer4.Admin.Api.Infrastructure;
using IdentityServer4.Admin.Api.Infrastructure.FluentValidation;
using IdentityServer4.Admin.Api.Mappers;
using Microsoft.AspNetCore.Http;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdentityServer4.Admin.Api.Services
{
    public class ApiResourceService : ServiceBase
    {
        public ApiResourceService(ISessionFactory sessionFactory, IHttpContextAccessor contextAccessor) : base(sessionFactory, contextAccessor)
        {
        }

        #region ApiResource
        public ApiResourceDto GetApiResourceDto(int? id)
        {
            ApiResourceDto apiResourceDto=new ApiResourceDto();
            if (!id.HasValue)
            {
                return apiResourceDto;
            }
            if (id.Value <= 0)
            {
                return apiResourceDto;
            }
            ApiResource apiResource = this.Session.Get<ApiResource>(id.Value);

            apiResource.UserClaims = this.Session.CreateCriteria<ApiClaim>()
                .Add(NHibernate.Criterion.Restrictions.Eq("ApiResourceId",id.Value))
                .List<ApiClaim>()
                .ToList();

            return apiResource.ToModel();
        }

        public void AddApiResource(ApiResourceDto apiResourceDto)
        {
            ApiResource apiResource = apiResourceDto.ToEntity();
            if (!CanInsertApiResource(apiResource))
            {
                throw new FluentValidationException("ApiResource名称重复。");
            }
            var transaction=this.Session.BeginTransaction();
            try
            {
              
                this.Session.Save(apiResource);
                apiResourceDto.UserClaims.ForEach(type =>
                {
                    ApiClaim apiClaim = new ApiClaim();
                    apiClaim.ApiResourceId = apiResource.Id;
                    apiClaim.Type = type;
                    this.Session.Save(apiClaim);
                });
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }

        }

        public void UpdateApiResource(int id, ApiResourceDto apiResourceDto)
        {
            ApiResource apiResource = this.Session.Get<ApiResource>(id);
            apiResource = apiResourceDto.ToEntity(apiResource);
            if (!CanInsertApiResource(apiResource))
            {
                throw new FluentValidationException("ApiResource名称重复。");
            }
            var transaction = this.Session.BeginTransaction();
            try
            {
               
                this.Session.Update(apiResource);

                this.Session.CreateQuery("delete from ApiClaim where ApiResourceId=:ApiResourceId")
                    .SetInt32("ApiResourceId", id)
                    .ExecuteUpdate();

                apiResourceDto.UserClaims.ForEach(type =>
                {
                    ApiClaim apiClaim = new ApiClaim();
                    apiClaim.ApiResourceId = apiResource.Id;
                    apiClaim.Type = type;
                    this.Session.Save(apiClaim);
                });
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

  

        public void DeleteApiResource(int id)
        {
            ApiResource  apiResource= this.Session.Get<ApiResource>(id);
            if (apiResource == null)
                return;
            var transaction = this.Session.BeginTransaction();
            try
            {
                this.Session.CreateQuery("delete from ApiClaim where ApiResourceId=:ApiResourceId")
                    .SetInt32("ApiResourceId", id)
                    .ExecuteUpdate();

                this.Session.Delete(apiResource);

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }
        public  bool CanInsertApiResource(ApiResource apiResource)
        {
            if (apiResource.Id == 0)
            {
                var existsWithSameName = this.Session.CreateCriteria<ApiResource>()
                    .Add(Restrictions.Eq("Name", apiResource.Name))
                    .List<ApiResource>()
                    .FirstOrDefault();
                return existsWithSameName == null;
            }
            else
            {
                var existsWithSameName = this.Session.CreateCriteria<ApiResource>()
                    .Add(Restrictions.Eq("Name", apiResource.Name))
                    .Add(Restrictions.Not(Restrictions.Eq("Id", apiResource.Id)))
                    .List<ApiResource>()
                    .FirstOrDefault();
                return existsWithSameName == null;
            }
        }

   
        #endregion

        #region ApiScope
        public List<ApiScopeListDto> GetApiScopes(int apiResourceId)
        {
           return this.Session.CreateCriteria<ApiScope>()
                  .Add(NHibernate.Criterion.Restrictions.Eq("ApiResourceId", apiResourceId))
                  .List<ApiScope>()
                  .ToList()
                  .ToModel();
        }
        public ApiScopeDto GetApiScopeDto(int? id)
        {
            ApiScopeDto apiScopeDto = new ApiScopeDto();
            if (!id.HasValue)
            {
                return apiScopeDto;
            }
            if (id.Value <= 0)
            {
                return apiScopeDto;
            }
            ApiScope apiScope = this.Session.Get<ApiScope>(id.Value);

            apiScope.UserClaims = this.Session.CreateCriteria<ApiScopeClaim>()
                .Add(NHibernate.Criterion.Restrictions.Eq("ApiScopeId", id.Value))
                .List<ApiScopeClaim>()
                .ToList();

            return apiScope.ToModel();
        }

        public void AddApiScope(ApiScopeDto apiScopeDto)
        {
            ApiScope apiScope = apiScopeDto.ToEntity();
            if (!CanInsertApiScope(apiScope))
            {
                throw new FluentValidationException("ApiScope名称重复。");
            }
            var transaction = this.Session.BeginTransaction();
            try
            {

                this.Session.Save(apiScope);
                apiScopeDto.UserClaims.ForEach(type =>
                {
                    ApiScopeClaim apiScopeClaim = new ApiScopeClaim();
                    apiScopeClaim.ApiScopeId = apiScope.Id;
                    apiScopeClaim.Type = type;
                    this.Session.Save(apiScopeClaim);
                });
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }

        }

        public void UpdateApiScope(int id, ApiScopeDto apiScopeDto)
        {
            ApiScope apiScope = this.Session.Get<ApiScope>(id);
            apiScope = apiScopeDto.ToEntity(apiScope);
            if (!CanInsertApiScope(apiScope))
            {
                throw new FluentValidationException("ApiScope名称重复。");
            }
            var transaction = this.Session.BeginTransaction();
            try
            {

                this.Session.Update(apiScope);

                this.Session.CreateQuery("delete from ApiScopeClaim where ApiScopeId=:ApiScopeId")
                    .SetInt32("ApiScopeId", id)
                    .ExecuteUpdate();

                apiScopeDto.UserClaims.ForEach(type =>
                {
                    ApiScopeClaim apiScopeClaim = new ApiScopeClaim();
                    apiScopeClaim.ApiScopeId = apiScope.Id;
                    apiScopeClaim.Type = type;
                    this.Session.Save(apiScopeClaim);
                });
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public void DeleteApiScope(int id)
        {
            ApiScope apiScope = this.Session.Get<ApiScope>(id);
            if (apiScope == null)
                return;
            var transaction = this.Session.BeginTransaction();
            try
            {
                this.Session.CreateQuery("delete from ApiScopeClaim where ApiScopeId=:ApiScopeId")
                    .SetInt32("ApiScopeId", id)
                    .ExecuteUpdate();

                this.Session.Delete(apiScope);

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }
        public bool CanInsertApiScope(ApiScope apiScope)
        {
            if (apiScope.Id == 0)
            {
                var existsWithSameName = this.Session.CreateCriteria<ApiScope>()
                    .Add(Restrictions.Eq("Name", apiScope.Name))
                    .List<ApiScope>()
                    .FirstOrDefault();
                return existsWithSameName == null;
            }
            else
            {
                var existsWithSameName = this.Session.CreateCriteria<ApiScope>()
                    .Add(Restrictions.Eq("Name", apiScope.Name))
                    .Add(Restrictions.Not(Restrictions.Eq("Id", apiScope.Id)))
                    .List<ApiScope>()
                    .FirstOrDefault();
                return existsWithSameName == null;
            }
        }
        #endregion
        #region ApiResourceProperty
        public List<ApiPropertyListDto> GetApiProperties(int apiResourceId)
        {
            return this.Session.CreateCriteria<ApiProperty>()
                  .Add(Restrictions.Eq("ApiResourceId", apiResourceId))
                  .AddOrder(Order.Asc("Key"))
                  .List<ApiProperty>()
                  .ToList()
                  .ToModel();
        }
        public void DeleteApiProperty(int id)
        {
            var apiProperty = this.Session.Get<ApiProperty>(id);
            if (apiProperty == null)
                return;
            var transaction = this.Session.BeginTransaction();
            try
            {
                this.Session.Delete(apiProperty);
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }
        public void AddApiProperty(ApiPropertyDto apiPropertyDto)
        {
            var transaction = this.Session.BeginTransaction();
            try
            {
                var apiProperty = apiPropertyDto.ToEntity();
                this.Session.Save(apiProperty);

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public void UpdateApiProperty(int id, ApiPropertyDto apiPropertyDto)
        {
            var transaction = this.Session.BeginTransaction();
            try
            {
                ApiProperty apiProperty = this.Session.Get<ApiProperty>(id);
                apiProperty = apiPropertyDto.ToEntity(apiProperty);
                this.Session.Update(apiProperty);

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public ApiPropertyDto GetApiProperty(int? id)
        {
            ApiPropertyDto apiPropertyDto = new ApiPropertyDto();
            if (!id.HasValue && id.GetValueOrDefault() <= 0)
            {
                return apiPropertyDto;
            }
            ApiProperty apiProperty = this.Session.Get<ApiProperty>(id.Value);
            if (apiProperty == null)
            {
                return apiPropertyDto;
            }
            return apiProperty.ToModel();
        }
        #endregion
        #region ApiResourceSecret
        public List<ApiSecretListDto> GetApiSecrets(int apiResourceId)
        {
            return this.Session.CreateCriteria<ApiSecret>()
                  .Add(Restrictions.Eq("ApiResourceId", apiResourceId))
                  .AddOrder(Order.Asc("Type"))
                  .List<ApiSecret>()
                  .ToList()
                  .ToModel();
        }
        public void DeleteApiSecret(int id)
        {
            var apiSecret = this.Session.Get<ApiSecret>(id);
            if (apiSecret == null)
                return;
            var transaction = this.Session.BeginTransaction();
            try
            {
                this.Session.Delete(apiSecret);
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }
        public void AddApiSecret(ApiSecretDto apiSecretDto)
        {
            apiSecretDto.HashApiSharedSecret();
            var transaction = this.Session.BeginTransaction();
            try
            {
                var apiSecret = apiSecretDto.ToEntity();
                this.Session.Save(apiSecret);

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public void UpdateApiSecret(int id, ApiSecretDto apiSecretDto)
        {
            apiSecretDto.HashApiSharedSecret();
            var transaction = this.Session.BeginTransaction();
            try
            {
                ApiSecret apiSecret = this.Session.Get<ApiSecret>(id);
                apiSecret = apiSecretDto.ToEntity(apiSecret);
                this.Session.Update(apiSecret);

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public ApiSecretDto GetApiSecret(int? id)
        {
            ApiSecretDto apiSecretDto = new ApiSecretDto();
            if (!id.HasValue && id.GetValueOrDefault() <= 0)
            {
                return apiSecretDto;
            }
            ApiSecret apiSecret = this.Session.Get<ApiSecret>(id.Value);
            if (apiSecret == null)
            {
                return apiSecretDto;
            }
            return apiSecret.ToModel();
        }
        #endregion
    }
}
