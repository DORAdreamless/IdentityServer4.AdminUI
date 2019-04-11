using IdentityServer4.Admin.Api.Infrastructure.UI;
using Microsoft.AspNetCore.Http;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace IdentityServer4.Admin.Api.Infrastructure.Domain
{
    public interface IRepository
    {
        NHibernate.ISession Session { get; }

        ClaimsPrincipal User { get; }


    }

    public interface ICrudRepository<T>: IRepository where T:class
    {
        void Save(T entity);

        void Update(T entity);

        T Get(object id);

        void Delete(T entity);

        void Delete(object id);

        PageResponse<T> GetByPage(PageRequest page);
    }
    public class NhSimpleRepository: IRepository
    {

        private readonly ISessionFactory sessionFactory;
        private readonly IHttpContextAccessor contextAccessor;
       

        public NhSimpleRepository(ISessionFactory sessionFactory, IHttpContextAccessor contextAccessor)
        {
            this.sessionFactory = sessionFactory;
            this.contextAccessor = contextAccessor;

            this.User = this.contextAccessor.HttpContext.User;
            this.Session = this.sessionFactory.OpenSession();
        }

        public NHibernate.ISession Session { get; }

        public ClaimsPrincipal User { get; }

        
    }

    public class NhCrudRepository<T> : NhSimpleRepository, ICrudRepository<T> where T : class
    {
        public NhCrudRepository(ISessionFactory sessionFactory, IHttpContextAccessor contextAccessor) : base(sessionFactory, contextAccessor)
        {
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public T Get(object id)
        {
            throw new NotImplementedException();
        }

        public PageResponse<T> GetByPage(PageRequest page)
        {
            var criteria=this.Session.CreateCriteria<T>();

            page.Criteria(ref criteria);

           int total= criteria.UniqueResult<int>();

           var list= criteria.SetFirstResult(0)
                .SetMaxResults(10)
                .List<T>();

            return new PageResponse<T>(list, total);
        }

        public void Save(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
