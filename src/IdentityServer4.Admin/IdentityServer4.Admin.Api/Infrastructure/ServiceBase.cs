using IdentityServer4.Admin.Api.Infrastructure.UI;
using Microsoft.AspNetCore.Http;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
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

    public abstract class ServiceBase<TEntity, TDto> : ServiceBase where TEntity:class
    {
        public ServiceBase(ISessionFactory sessionFactory, IHttpContextAccessor contextAccessor) : base(sessionFactory, contextAccessor)
        {
        }

        public PageList<TDto> GetByPage(PageRequest page)
        {
            var criteria = this.Session.CreateCriteria<TEntity>();
            page.PrepareCriteria(ref criteria);

            page.PrepareOrder(ref criteria);


            var list = criteria.SetFirstResult(page.GetFirstResult())
                .SetMaxResults(page.GetMaxResults())
                .List<TEntity>()
                .ToList();

            criteria = this.Session.CreateCriteria<TEntity>();
            page.PrepareCriteria(ref criteria);

           var mapper= new AutoMapper.MapperConfiguration(cfg =>{
                cfg.CreateMap<TEntity, TDto>();
            }).CreateMapper();

            int total = criteria.SetProjection(Projections.RowCount()).UniqueResult<int>();
            return new PageList<TDto>(mapper.Map<List<TDto>>(list), total);
        }
    }
}
