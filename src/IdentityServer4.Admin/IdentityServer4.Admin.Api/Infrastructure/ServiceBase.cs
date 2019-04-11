using Microsoft.AspNetCore.Http;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace IdentityServer4.Admin.Api.Infrastructure
{
   public abstract class ServiceBase
    {
        private readonly ISessionFactory sessionFactory;
        private readonly IHttpContextAccessor contextAccessor;


        public ServiceBase(ISessionFactory sessionFactory, IHttpContextAccessor contextAccessor)
        {
            this.sessionFactory = sessionFactory;
            this.contextAccessor = contextAccessor;

            this.User = this.contextAccessor.HttpContext.User;
            this.Session = this.sessionFactory.OpenSession();
        }

        public NHibernate.ISession Session { get; }

        public ClaimsPrincipal User { get; }
    }
}
