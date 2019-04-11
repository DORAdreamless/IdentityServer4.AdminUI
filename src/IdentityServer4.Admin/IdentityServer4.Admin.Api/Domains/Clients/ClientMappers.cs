using IdentityServer4.Admin.Api.Entities;

namespace IdentityServer4.Admin.Api.Domains.Clients
{
    public static class ClientMappers
    {
        static AutoMapper.IMapper Mapper = new AutoMapper.MapperConfiguration(cfg=> {
            cfg.AddProfile<ClientProfile>();
        }).CreateMapper();

        public static Client ToEntity(this ClientDto model,Client client=null)
        {
            return Mapper.Map<ClientDto, Client>(model, client);
        }

      

        public static ClientDto ToModel(this Client client)
        {
            return Mapper.Map<ClientDto>(client);
        }
    }
}
