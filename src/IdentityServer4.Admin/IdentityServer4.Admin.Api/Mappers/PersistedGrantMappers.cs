using AutoMapper;
using IdentityServer4.Admin.Api.Dtos.Grant;
using IdentityServer4.Admin.Api.Entities;

namespace IdentityServer4.Admin.Api.Mappers
{
    public static class PersistedGrantMappers
    {
        static PersistedGrantMappers()
        {
            Mapper = new MapperConfiguration(cfg =>cfg.AddProfile<PersistedGrantMapperProfile>())
                .CreateMapper();
        }

        internal static IMapper Mapper { get; }

        //public static PersistedGrantsDto ToModel(this PagedList<PersistedGrantDataView> grant)
        //{
        //    return grant == null ? null : Mapper.Map<PersistedGrantsDto>(grant);
        //}

        //public static PersistedGrantsDto ToModel(this PagedList<global::IdentityServer4.EntityFramework.Entities.PersistedGrant> grant)
        //{
        //    return grant == null ? null : Mapper.Map<PersistedGrantsDto>(grant);
        //}

        public static PersistedGrantDto ToModel(this PersistedGrant grant)
        {
            return grant == null ? null : Mapper.Map<PersistedGrantDto>(grant);
        }
    }
}