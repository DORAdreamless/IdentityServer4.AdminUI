using AutoMapper;
using IdentityServer4.Admin.Api.Dtos.Configuration;
using IdentityServer4.Admin.Api.Entities;
using System.Collections.Generic;

namespace IdentityServer4.Admin.Api.Mappers
{
    public static class ApiResourceMappers
    {
        static ApiResourceMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<ApiResourceMapperProfile>())
                .CreateMapper();
        }

        internal static IMapper Mapper { get; }
        #region ApiResources
        public static ApiResource ToEntity(this ApiResourceDto apiResourceDto, ApiResource apiResource = null)
        {
            return Mapper.Map<ApiResourceDto, ApiResource>(apiResourceDto, apiResource);
        }
        public static ApiResourceDto ToModel(this ApiResource apiResource)
        {
            return Mapper.Map<ApiResource, ApiResourceDto>(apiResource);
        }
        public static List<ApiResourceListDto> ToModel(this List<ApiResource> apiResources)
        {
            return Mapper.Map<List<ApiResource>, List<ApiResourceListDto>>(apiResources);
        }
        #endregion
        #region ApiScopes
        public static ApiScope ToEntity(this ApiScopeDto apiScopeDto, ApiScope apiScope = null)
        {
            return Mapper.Map<ApiScopeDto, ApiScope>(apiScopeDto, apiScope);
        }
        public static ApiScopeDto ToModel(this ApiScope apiScope)
        {
            return Mapper.Map<ApiScope, ApiScopeDto>(apiScope);
        }
        public static List<ApiScopeListDto> ToModel(this List<ApiScope> apiScopes)
        {
            return Mapper.Map<List<ApiScope>, List<ApiScopeListDto>>(apiScopes);
        }
        #endregion
        #region ApiSecret
        public static ApiSecret ToEntity(this ApiSecretDto apiSecretDto, ApiSecret apiSecret = null)
        {
            return Mapper.Map<ApiSecretDto, ApiSecret>(apiSecretDto, apiSecret);
        }
        public static ApiSecretDto ToModel(this ApiSecret apiSecret)
        {
            return Mapper.Map<ApiSecret, ApiSecretDto>(apiSecret);
        }
        public static List<ApiSecretListDto> ToModel(this List<ApiSecret> apiSecrets)
        {
            return Mapper.Map<List<ApiSecret>, List<ApiSecretListDto>>(apiSecrets);
        }
        #endregion
        #region ApiProperty
        public static ApiProperty ToEntity(this ApiPropertyDto apiPropertyDto, ApiProperty apiProperty = null)
        {
            return Mapper.Map<ApiPropertyDto, ApiProperty>(apiPropertyDto, apiProperty);
        }
        public static ApiPropertyDto ToModel(this ApiProperty apiProperty)
        {
            return Mapper.Map<ApiProperty, ApiPropertyDto>(apiProperty);
        }
        public static List<ApiPropertyListDto> ToModel(this List<ApiProperty> apiProperties)
        {
            return Mapper.Map<List<ApiProperty>, List<ApiPropertyListDto>>(apiProperties);
        }
        #endregion

    }
}