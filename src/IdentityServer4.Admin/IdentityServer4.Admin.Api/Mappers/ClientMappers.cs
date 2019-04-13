using AutoMapper;
using IdentityServer4.Admin.Api.Dtos.Configuration;
using IdentityServer4.Admin.Api.Entities;
using System.Collections.Generic;

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




   

        #region Clients
        public static Client ToEntity(this ClientDto clientDto, Client client = null)
        {
            return Mapper.Map<ClientDto, Client>(clientDto, client);
        }
        public static ClientDto ToModel(this Client client, ClientDto clientDto)
        {
            return Mapper.Map<Client, ClientDto>(client, clientDto);
        }
        public static List<ClientListDto> ToModel(this List<Client> clients)
        {
            return Mapper.Map<List<Client>, List<ClientListDto>>(clients);
        }
        #endregion
        #region ClientSecrets
        public static ClientSecret ToEntity(this ClientSecretDto clientSecretDto, ClientSecret clientSecret = null)
        {
            return Mapper.Map<ClientSecretDto, ClientSecret>(clientSecretDto, clientSecret);
        }
        public static ClientSecretDto ToModel(this ClientSecret clientSecret)
        {
            return Mapper.Map<ClientSecret, ClientSecretDto>(clientSecret);
        }
        public static List<ClientSecretListDto> ToModel(this List<ClientSecret> clientSecrets)
        {
            return Mapper.Map<List<ClientSecret>, List<ClientSecretListDto>>(clientSecrets);
        }
        #endregion
        #region ClientProperties
        public static ClientProperty ToEntity(this ClientPropertyDto clientPropertyDto, ClientProperty clientProperty = null)
        {
            return Mapper.Map<ClientPropertyDto, ClientProperty>(clientPropertyDto, clientProperty);
        }
        public static ClientPropertyDto ToModel(this ClientProperty clientProperty)
        {
            return Mapper.Map<ClientProperty, ClientPropertyDto>(clientProperty);
        }
        public static List<ClientPropertyListDto> ToModel(this List<ClientProperty> clientProperties)
        {
            return Mapper.Map<List<ClientProperty>, List<ClientPropertyListDto>>(clientProperties);
        }
        #endregion
    }
}