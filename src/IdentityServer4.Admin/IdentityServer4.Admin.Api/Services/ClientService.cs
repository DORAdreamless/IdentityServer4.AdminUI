using IdentityServer4.Admin.Api.Infrastructure;
using IdentityServer4.Admin.Api.Infrastructure.FluentValidation;
using IdentityServer4.Admin.Api.Entities;
using Microsoft.AspNetCore.Http;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;
using IdentityServer4.Admin.Api.Dtos.Configuration;
using IdentityServer4.Admin.Api.Mappers;

namespace IdentityServer4.Admin.Api.Services
{
    public class ClientService : ServiceBase
    {
        public ClientService(ISessionFactory sessionFactory, IHttpContextAccessor contextAccessor) : base(sessionFactory, contextAccessor)
        {
        }

        public void CreateClient(ClientDto clientDto)
        {
            Client client = clientDto.ToEntity();
            this.Session.Save(client);
            this.Session.Flush();
        }

        public void UpdateClientName(int id, ClientDto clientDto)
        {
            Client client = this.Session.Get<Client>(id);
            if (client == null)
            {
                throw new FluentValidationException($"客户端{id}不存在。");
            }
            client.ClientId = clientDto.ClientId;
            this.Session.Update(client);
            this.Session.Flush();
        }

        public void Delete(int id)
        {
            Client client = this.Session.Get<Client>(id);
            if (client == null)
            {
                return;
            }
            this.Session.Delete(client);
            this.Session.Flush();
        }

        public void UpdateClientToken(int id,ClientDto clientDto)
        {
            Client client = this.Session.Get<Client>(id);
            if (client == null)
            {
                throw new FluentValidationException($"客户端{id}不存在。");
            }
            client.ClientId = clientDto.ClientId;

            var transaction=this.Session.BeginTransaction();
            try
            {
                this.Session.Update(client);

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
           
        }
    }
}
