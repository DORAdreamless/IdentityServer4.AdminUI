using System.Collections.Generic;
using AutoMapper;
using IdentityServer4.Admin.Api.Dtos.Configuration;
using IdentityServer4.Admin.Api.Entities;

namespace IdentityServer4.Admin.Api.Mappers
{
    public static class IdentityResourceMappers
    {
        static IdentityResourceMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<IdentityResourceMapperProfile>())
                .CreateMapper();
        }

        internal static IMapper Mapper { get; }


        public static IdentityResourceDto ToModel(this IdentityResource resource)
        {
            return resource == null ? null : Mapper.Map<IdentityResourceDto>(resource);
        }

        //public static IdentityResourcesDto ToModel(this PagedList<IdentityResource> resource)
        //{
        //    return resource == null ? null : Mapper.Map<IdentityResourcesDto>(resource);
        //}

        public static List<IdentityResourceDto> ToModel(this List<IdentityResource> resource)
        {
            return resource == null ? null : Mapper.Map<List<IdentityResourceDto>>(resource);
        }

        public static IdentityResource ToEntity(this IdentityResourceDto identityResourceDto, IdentityResource identityResource=null)
        {
            return identityResourceDto == null ? null : Mapper.Map<IdentityResourceDto,IdentityResource>(identityResourceDto, identityResource);
        }

        public static List<IdentityPropertyDto> ToModel(this List<IdentityProperty> identityResourceProperties)
        {
            return Mapper.Map<List<IdentityPropertyDto>>(identityResourceProperties);
        }

        public static IdentityPropertyDto ToModel(this IdentityProperty identityResourceProperty)
        {
            return Mapper.Map<IdentityPropertyDto>(identityResourceProperty);
        }

        public static List<IdentityResource> ToEntity(this List<IdentityResourceDto> resource)
        {
            return resource == null ? null : Mapper.Map<List<IdentityResource>>(resource);
        }

        public static IdentityProperty ToEntity(this IdentityPropertyDto identityResourcePropertyDto, IdentityProperty identityResourceProperty=null)
        {
            return Mapper.Map<IdentityPropertyDto,IdentityProperty>(identityResourcePropertyDto, identityResourceProperty);
        }
    }
}