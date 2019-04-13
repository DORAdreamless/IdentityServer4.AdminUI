// Based on the IdentityServer4.EntityFramework - authors - Brock Allen & Dominick Baier.
// https://github.com/IdentityServer/IdentityServer4.EntityFramework

// Modified by Jan Škoruba

using System.Linq;
using AutoMapper;
using IdentityServer4.Admin.Api.Dtos.Configuration;
using IdentityServer4.Admin.Api.Entities;

namespace IdentityServer4.Admin.Api.Mappers
{
    public class ApiResourceMapperProfile : Profile
    {
        public ApiResourceMapperProfile()
        {
            // entity to model
            CreateMap<ApiResource, ApiResourceDto>(MemberList.Destination)
                .ForMember(x => x.UserClaims, opts => opts.MapFrom(src => src.UserClaims.Select(x => x.Type)));
            

            CreateMap<ApiScope, ApiScopeDto>(MemberList.Destination)
                .ForMember(x => x.UserClaims, opt => opt.MapFrom(src => src.UserClaims.Select(x => x.Type)));

         

            CreateMap<ApiSecret, ApiSecretDto>().ReverseMap();
            CreateMap<ApiSecret, ApiSecretListDto>();

            CreateMap<ApiProperty, ApiPropertyDto>(MemberList.Destination)
                .ReverseMap();
            

            //PagedLists
            //CreateMap<PagedList<ApiResource>, ApiResourcesDto>(MemberList.Destination)
            //    .ForMember(x => x.ApiResources, opt => opt.MapFrom(src => src.Data));

            //CreateMap<PagedList<ApiScope>, ApiScopesDto>(MemberList.Destination)
            //    .ForMember(x => x.Scopes, opt => opt.MapFrom(src => src.Data));

            //CreateMap<PagedList<ApiSecret>, ApiSecretsDto>(MemberList.Destination)
            //    .ForMember(x => x.ApiSecrets, opt => opt.MapFrom(src => src.Data));

            //CreateMap<PagedList<ApiResourceProperty>, ApiResourcePropertiesDto>(MemberList.Destination)
            //    .ForMember(x => x.ApiResourceProperties, opt => opt.MapFrom(src => src.Data));

            // model to entity
            CreateMap<ApiResourceDto, ApiResource>(MemberList.Source)
                .ForMember(x => x.UserClaims, opts => opts.MapFrom(src => src.UserClaims.Select(x => new ApiClaim { Type = x })));

       
            

            CreateMap<ApiScopeDto, ApiScope>(MemberList.Source)
                .ForMember(x => x.UserClaims, opts => opts.MapFrom(src => src.UserClaims.Select(x => new ApiScopeClaim { Type = x })));
            
        }
    }
}
