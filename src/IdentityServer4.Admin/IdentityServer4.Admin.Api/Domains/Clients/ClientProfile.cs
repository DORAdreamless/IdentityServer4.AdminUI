using AutoMapper;
using IdentityServer4.Admin.Api.Entities;

namespace IdentityServer4.Admin.Api.Domains.Clients
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {

            this.CreateMap<ClientDto, Client>().ReverseMap();
        }
    }
}
