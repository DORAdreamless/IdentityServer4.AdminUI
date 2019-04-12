using AutoMapper;
using IdentityServer4.Admin.Api.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Api.Domains
{
   public class IdentityResourceDto
    {
    }

    public class IdentityResourceProfile : Profile
    {
        public IdentityResourceProfile()
        {
            this.CreateMap<IdentityResource, IdentityResourceDto>().ReverseMap();
        }
    }

    public static class IdentityResourceMappers
    {
        static IMapper Mapper = new MapperConfiguration(cfg=>cfg.AddProfile<IdentityResourceProfile>())
            .CreateMapper();

        public static IdentityResourceDto ToModel(this IdentityResource identityResource, IdentityResourceDto identityResourceDto)
        {
            return Mapper.Map<IdentityResource, IdentityResourceDto>(identityResource, identityResourceDto);
        }
    }
}
