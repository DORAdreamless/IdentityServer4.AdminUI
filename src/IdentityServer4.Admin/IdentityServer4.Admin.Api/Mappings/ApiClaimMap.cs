using IdentityServer4.Admin.Api.Entities;
using IdentityServer4.Admin.Api.Infrastructure.Data;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace IdentityServer4.Admin.Api.Mappings
{
    public class ApiClaimMap: ClassMapping<ApiClaim>, IEntityMaping
    {
        public ApiClaimMap()
        {
            this.Table("ApiClaims");
            // Id
            this.Id(x => x.Id, map => {
                map.Generator(Generators.Identity);
            });

            // Type
            this.Property(x => x.Type, map => {
                map.NotNullable(true);
                map.Length(200);
            });

            // ApiResourceId
            this.Property(x => x.ApiResourceId, map => {
                map.NotNullable(true);
            });
        }
    }
}

