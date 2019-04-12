﻿using AutoMapper;
using IdentityServer4.Admin.Api.Dtos.Configuration;
using IdentityServer4.Admin.Api.Entities;


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

        public static ApiResourceDto ToModel(this ApiResource resource)
        {
            return resource == null ? null : Mapper.Map<ApiResourceDto>(resource);
        }

        //public static ApiResourcesDto ToModel(this PagedList<ApiResource> resources)
        //{
        //    return resources == null ? null : Mapper.Map<ApiResourcesDto>(resources);
        //}

        //public static ApiResourcePropertiesDto ToModel(this PagedList<ApiResourceProperty> apiResourceProperties)
        //{
        //    return Mapper.Map<ApiResourcePropertiesDto>(apiResourceProperties);
        //}

        public static ApiResourcePropertiesDto ToModel(this ApiProperty apiResourceProperty)
        {
            return Mapper.Map<ApiResourcePropertiesDto>(apiResourceProperty);
        }

        //public static ApiSecretsDto ToModel(this PagedList<ApiSecret> secrets)
        //{
        //    return secrets == null ? null : Mapper.Map<ApiSecretsDto>(secrets);
        //}

        //public static ApiScopesDto ToModel(this PagedList<ApiScope> scopes)
        //{
        //    return scopes == null ? null : Mapper.Map<ApiScopesDto>(scopes);
        //}

        public static ApiScopesDto ToModel(this ApiScope resource)
        {
            return resource == null ? null : Mapper.Map<ApiScopesDto>(resource);
        }

        public static ApiSecretsDto ToModel(this ApiSecret resource)
        {
            return resource == null ? null : Mapper.Map<ApiSecretsDto>(resource);
        }

        public static ApiResource ToEntity(this ApiResourceDto resource)
        {
            return resource == null ? null : Mapper.Map<ApiResource>(resource);
        }

        public static ApiSecret ToEntity(this ApiSecretsDto resource)
        {
            return resource == null ? null : Mapper.Map<ApiSecret>(resource);
        }

        public static ApiScope ToEntity(this ApiScopesDto resource)
        {
            return resource == null ? null : Mapper.Map<ApiScope>(resource);
        }

        public static ApiProperty ToEntity(this ApiResourcePropertiesDto apiResourceProperties)
        {
            return Mapper.Map<ApiProperty>(apiResourceProperties);
        }
    }
}