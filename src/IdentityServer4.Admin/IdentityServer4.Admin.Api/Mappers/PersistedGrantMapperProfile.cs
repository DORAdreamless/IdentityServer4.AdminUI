using AutoMapper;
using IdentityServer4.Admin.Api.Dtos.Grant;
using IdentityServer4.Admin.Api.Entities;

namespace IdentityServer4.Admin.Api.Mappers
{
    public class PersistedGrantMapperProfile : Profile
    {
        public PersistedGrantMapperProfile()
        {
            // entity to model
            CreateMap<PersistedGrant, PersistedGrantDto>(MemberList.Destination)
                .ReverseMap();

            //CreateMap<PersistedGrantDataView, PersistedGrantDto>(MemberList.Destination);

            //CreateMap<PagedList<PersistedGrantDataView>, PersistedGrantsDto>(MemberList.Destination)
            //    .ForMember(x => x.PersistedGrants,
            //        opt => opt.MapFrom(src => src.Data));

            //CreateMap<PagedList<PersistedGrant>, PersistedGrantsDto>(MemberList.Destination)
            //    .ForMember(x => x.PersistedGrants,
            //        opt => opt.MapFrom(src => src.Data));            
        }
    }
}
