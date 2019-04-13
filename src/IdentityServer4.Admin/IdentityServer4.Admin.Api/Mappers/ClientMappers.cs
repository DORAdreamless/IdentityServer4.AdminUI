using AutoMapper;
using IdentityServer4.Admin.Api.Dtos.Configuration;
using IdentityServer4.Admin.Api.Entities;


namespace IdentityServer4.Admin.Api.Mappers
{
    public static class ClientMappers
    {
        static ClientMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<ClientMapperProfile>())
                .CreateMapper();
        }

        internal static IMapper Mapper { get; }

        public static ClientDto ToModel(this Client client,ClientDto clientDto)
        {
            return Mapper.Map<Client,ClientDto>(client, clientDto);
        }

        //public static ClientSecretsDto ToModel(this PagedList<ClientSecret> clientSecret)
        //{
        //    return Mapper.Map<ClientSecretsDto>(clientSecret);
        //}

        //public static ClientClaimsDto ToModel(this PagedList<ClientClaim> clientClaims)
        //{
        //    return Mapper.Map<ClientClaimsDto>(clientClaims);
        //}

        //public static ClientsDto ToModel(this PagedList<Client> clients)
        //{
        //    return Mapper.Map<ClientsDto>(clients);
        //}

        //public static ClientPropertiesDto ToModel(this PagedList<ClientProperty> clientProperties)
        //{
        //    return Mapper.Map<ClientPropertiesDto>(clientProperties);
        //}
        
		public static Client ToEntity(this ClientDto client)
        {
            return Mapper.Map<Client>(client);
        }

		public static ClientSecretsDto ToModel(this ClientSecret clientSecret)
		{
			return Mapper.Map<ClientSecretsDto>(clientSecret);
		}
        
        public static ClientSecret ToEntity(this ClientSecretsDto clientSecret)
		{
			return Mapper.Map<ClientSecret>(clientSecret);
		}

        public static ClientClaimsDto ToModel(this ClientClaim clientClaim)
		{
			return Mapper.Map<ClientClaimsDto>(clientClaim);
		}

        public static ClientPropertiesDto ToModel(this ClientProperty clientProperty)
        {
            return Mapper.Map<ClientPropertiesDto>(clientProperty);
        }

        public static ClientClaim ToEntity(this ClientClaimsDto clientClaim)
		{
			return Mapper.Map<ClientClaim>(clientClaim);
		}

        public static ClientProperty ToEntity(this ClientPropertiesDto clientProperties)
        {
            return Mapper.Map<ClientProperty>(clientProperties);
        }
    }
}