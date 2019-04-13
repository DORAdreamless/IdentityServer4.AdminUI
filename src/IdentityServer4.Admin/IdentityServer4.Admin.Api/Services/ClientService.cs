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
using System.Linq;

namespace IdentityServer4.Admin.Api.Services
{
    public class ClientService : ServiceBase
    {
        public ClientService(ISessionFactory sessionFactory, IHttpContextAccessor contextAccessor) : base(sessionFactory, contextAccessor)
        {
        }

        public   bool CanInsertClient(Client client)
        {
            if (client.Id == 0 )
            {
                var existsWithClientName =  this.Session.CreateCriteria<Client>()
                    .Add(NHibernate.Criterion.Restrictions.Eq("ClientId", client.ClientId))
                    .List<Client>()
                    .FirstOrDefault();
                return existsWithClientName == null;
            }
            else
            {
                var existsWithClientName = this.Session.CreateCriteria<Client>()
                  .Add(NHibernate.Criterion.Restrictions.Eq("ClientId", client.ClientId))
                   .Add(NHibernate.Criterion.Restrictions.Not(NHibernate.Criterion.Restrictions.Eq("Id", client.Id)))
                  .List<Client>()
                  .FirstOrDefault();
                return existsWithClientName == null;
            }
        }

        public void AddClient(ClientDto clientDto)
        {
            Client client = clientDto.ToEntity();
            if (!CanInsertClient(client))
            {
                throw new Infrastructure.FluentValidation.FluentValidationException("客户端ID重复。");
            }
            var transaction=this.Session.BeginTransaction();
            try
            {
                this.Session.Save(client);

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
            
        }
        public void UpdateClientName(int id, ClientDto clientDto)
        {
            Client client = this.Session.Get<Client>(id);
            if (client == null)
            {
                throw new FluentValidationException($"客户端{id}不存在。");
            }

            client.ClientId = clientDto.ClientId;
            client.ClientName = clientDto.ClientName;
            client.ClientUri = clientDto.ClientUri;
            client.LogoUri = clientDto.LogoUri;
            if (!CanInsertClient(client))
            {
                throw new Infrastructure.FluentValidation.FluentValidationException("客户端ID重复。");
            }
            var transaction = this.Session.BeginTransaction();
            try
            {
                this.Session.Update(client);

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }

        }



        public void UpdateClientBasic(int id, ClientDto clientDto)
        {
            Client client = this.Session.Get<Client>(id);
            if (client == null)
            {
                throw new FluentValidationException($"客户端{id}不存在。");
            }
            client.Description = clientDto.Description;
            client.ProtocolType = clientDto.ProtocolType;
            client.RequireClientSecret = clientDto.RequireClientSecret;
            client.RequirePkce = clientDto.RequirePkce;
            client.AllowPlainTextPkce = clientDto.AllowPlainTextPkce;
            client.AllowOfflineAccess = clientDto.AllowOfflineAccess;
            client.AllowAccessTokensViaBrowser = clientDto.AllowAccessTokensViaBrowser;
            client.Enabled = clientDto.Enabled;

            var transaction = this.Session.BeginTransaction();
            try
            {
                this.Session.Update(client);

                this.Session.CreateQuery("delete from ClientScope where ClientId=:ClientId")
                    .SetInt32("ClientId", id)
                    .ExecuteUpdate();

                clientDto.AllowedScopes.ForEach(scope =>
                {
                    ClientScope clientScope = new ClientScope();
                    clientScope.ClientId = client.Id;
                    clientScope.Scope = scope;
                    this.Session.Save(clientScope);
                });


                this.Session.CreateQuery("delete from ClientRedirectUri where ClientId=:ClientId")
                    .SetInt32("ClientId", id)
                    .ExecuteUpdate();

                clientDto.RedirectUris.ForEach(redirectUri =>
                {
                    ClientRedirectUri clientRedirectUri = new ClientRedirectUri();
                    clientRedirectUri.ClientId = client.Id;
                    clientRedirectUri.RedirectUri = redirectUri;
                    this.Session.Save(clientRedirectUri);
                });

                this.Session.CreateQuery("delete from ClientGrantType where ClientId=:ClientId")
                    .SetInt32("ClientId", id)
                    .ExecuteUpdate();

                clientDto.AllowedGrantTypes.ForEach(grantType =>
                {
                    ClientGrantType clientGrantType = new ClientGrantType();
                    clientGrantType.ClientId = client.Id;
                    clientGrantType.GrantType = grantType;
                    this.Session.Save(clientGrantType);
                });

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        
        }

        public void UpdateClientDeviceFlow(int id, ClientDto clientDto)
        {
            Client client = this.Session.Get<Client>(id);
            if (client == null)
            {
                throw new FluentValidationException($"客户端{id}不存在。");
            }
            client.DeviceCodeLifetime = clientDto.DeviceCodeLifetime;
            client.UserCodeType = clientDto.UserCodeType;
            var transaction = this.Session.BeginTransaction();
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

        public void DeleteClient(int id)
        {
            
        }

        public void UpdateClientAuthorization(int id, ClientDto clientDto)
        {
            Client client = this.Session.Get<Client>(id);
            if (client == null)
            {
                throw new FluentValidationException($"客户端{id}不存在。");
            }
            client.FrontChannelLogoutUri = clientDto.FrontChannelLogoutUri;
            client.FrontChannelLogoutSessionRequired = clientDto.FrontChannelLogoutSessionRequired;
            client.BackChannelLogoutUri = clientDto.BackChannelLogoutUri;
            client.BackChannelLogoutSessionRequired = clientDto.BackChannelLogoutSessionRequired;
            client.EnableLocalLogin = clientDto.EnableLocalLogin;
            client.UserSsoLifetime = clientDto.UserSsoLifetime;

            var transaction = this.Session.BeginTransaction();
            try
            {
                this.Session.Update(client);

                this.Session.CreateQuery("delete from ClientPostLogoutRedirectUri where ClientId=:ClientId")
                     .SetInt32("ClientId", id)
                     .ExecuteUpdate();

                clientDto.PostLogoutRedirectUris.ForEach(postLogoutRedirectUri =>
                {
                    ClientPostLogoutRedirectUri clientPostLogoutRedirectUri = new ClientPostLogoutRedirectUri();
                    clientPostLogoutRedirectUri.ClientId = client.Id;
                    clientPostLogoutRedirectUri.PostLogoutRedirectUri = postLogoutRedirectUri;
                    this.Session.Save(clientPostLogoutRedirectUri);
                });

                this.Session.CreateQuery("delete from ClientIdPRestriction where ClientId=:ClientId")
                     .SetInt32("ClientId", id)
                     .ExecuteUpdate();

                clientDto.IdentityProviderRestrictions.ForEach(provider =>
                {
                    ClientIdPRestriction clientIdPRestriction = new ClientIdPRestriction();
                    clientIdPRestriction.ClientId = client.Id;
                    clientIdPRestriction.Provider = provider;
                    this.Session.Save(clientIdPRestriction);
                });

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public void UpdateClientConsent(int id, ClientDto clientDto)
        {
            Client client = this.Session.Get<Client>(id);
            if (client == null)
            {
                throw new FluentValidationException($"客户端{id}不存在。");
            }
            client.RequireConsent = clientDto.RequireConsent;
            client.AllowRememberConsent = clientDto.AllowRememberConsent;
            client.ClientUri = clientDto.ClientUri;
            client.LogoUri = clientDto.LogoUri;

            var transaction = this.Session.BeginTransaction();
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

        public ClientDto GetClient(int? id)
        {
            ClientDto clientDto = new ClientDto();
            if (!id.HasValue)
            {
                return clientDto;
            }
            if (id.Value <= 0)
            {
                return clientDto;
            }
           Client client= this.Session.Get<Client>(id.Value);
            if (client == null)
                return clientDto;
            client.AllowedScopes = this.Session.CreateCriteria<ClientScope>()
                .Add(NHibernate.Criterion.Restrictions.Eq("ClientId", id.Value))
                .List<ClientScope>()
                .ToList();
            client.RedirectUris = this.Session.CreateCriteria<ClientRedirectUri>()
                .Add(NHibernate.Criterion.Restrictions.Eq("ClientId", id.Value))
                .List<ClientRedirectUri>()
                .ToList();
            client.AllowedGrantTypes = this.Session.CreateCriteria<ClientGrantType>()
                .Add(NHibernate.Criterion.Restrictions.Eq("ClientId", id.Value))
                .List<ClientGrantType>()
                .ToList();
            client.PostLogoutRedirectUris = this.Session.CreateCriteria<ClientPostLogoutRedirectUri>()
               .Add(NHibernate.Criterion.Restrictions.Eq("ClientId", id.Value))
               .List<ClientPostLogoutRedirectUri>()
               .ToList();
            client.IdentityProviderRestrictions = this.Session.CreateCriteria <ClientIdPRestriction>()
               .Add(NHibernate.Criterion.Restrictions.Eq("ClientId", id.Value))
               .List<ClientIdPRestriction>()
               .ToList();
            client.AllowedCorsOrigins = this.Session.CreateCriteria<ClientCorsOrigin>()
             .Add(NHibernate.Criterion.Restrictions.Eq("ClientId", id.Value))
             .List<ClientCorsOrigin>()
             .ToList();
            return client.ToModel(clientDto);
        }

      

        public void UpdateClientToken(int id,ClientDto clientDto)
        {
            Client client = this.Session.Get<Client>(id);
            if (client == null)
            {
                throw new FluentValidationException($"客户端{id}不存在。");
            }
            client.IdentityTokenLifetime = clientDto.IdentityTokenLifetime;
            client.AccessTokenLifetime = clientDto.AccessTokenLifetime;
            client.AccessTokenType = clientDto.AccessTokenType;
            client.AuthorizationCodeLifetime = clientDto.AuthorizationCodeLifetime;
            client.AbsoluteRefreshTokenLifetime = clientDto.AbsoluteRefreshTokenLifetime;
            client.SlidingRefreshTokenLifetime = clientDto.SlidingRefreshTokenLifetime;
            client.RefreshTokenUsage = clientDto.RefreshTokenUsage;
            client.RefreshTokenExpiration = clientDto.RefreshTokenExpiration;
            client.UpdateAccessTokenClaimsOnRefresh = clientDto.UpdateAccessTokenClaimsOnRefresh;
            client.IncludeJwtId = clientDto.IncludeJwtId;
            client.AlwaysSendClientClaims = clientDto.AlwaysSendClientClaims;
            client.AlwaysIncludeUserClaimsInIdToken = clientDto.AlwaysIncludeUserClaimsInIdToken;
            client.ClientClaimsPrefix = clientDto.ClientClaimsPrefix;
            client.PairWiseSubjectSalt = clientDto.PairWiseSubjectSalt;

            var transaction=this.Session.BeginTransaction();
            try
            {
                this.Session.Update(client);

                this.Session.CreateQuery("delete from ClientCorsOrigin where ClientId=:ClientId")
                     .SetInt32("ClientId", id)
                     .ExecuteUpdate();

                clientDto.AllowedCorsOrigins.ForEach(origin =>
                {
                   ClientCorsOrigin clientCorsOrigin = new ClientCorsOrigin();
                    clientCorsOrigin.ClientId = client.Id;
                    clientCorsOrigin.Origin = origin;
                    this.Session.Save(clientCorsOrigin);
                });

                this.Session.CreateQuery("delete from ClientClaim where ClientId=:ClientId")
                     .SetInt32("ClientId", id)
                     .ExecuteUpdate();

                clientDto.Claims.ForEach(claim =>
                {
                    ClientClaim clientClaim = new ClientClaim();
                    clientClaim.ClientId = client.Id;
                    clientClaim.Type = claim.Type;
                    clientClaim.Value = claim.Value;
                    this.Session.Save(clientClaim);
                });

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
