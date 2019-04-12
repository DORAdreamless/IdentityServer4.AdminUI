using IdentityServer4.Admin.Api.Dtos.Configuration;
using IdentityServer4.Admin.Api.Entities;
using IdentityServer4.Admin.Api.Infrastructure;
using IdentityServer4.Admin.Api.Infrastructure.UI;
using IdentityServer4.Admin.Api.Mappers;
using Microsoft.AspNetCore.Http;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdentityServer4.Admin.Api.Services
{
    public class IdentityResourceService : ServiceBase
    {
        public IdentityResourceService(ISessionFactory sessionFactory, IHttpContextAccessor contextAccessor) : base(sessionFactory, contextAccessor)
        {
        }

        #region IdentityResource
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IdentityResourceDto GetIdentityResourceDto(int? id)
        {
            IdentityResourceDto identityResourceDto = new IdentityResourceDto();
            if (!id.HasValue && id.GetValueOrDefault() <= 0)
            {
                return identityResourceDto;
            }
            IdentityResource identityResource = this.Session.Get<IdentityResource>(id.Value);
            if (identityResource == null)
            {
                return identityResourceDto;
            }
            identityResourceDto= identityResource.ToModel();

            identityResourceDto.UserClaims =
                this.Session.CreateCriteria<IdentityClaim>()
                .Add(Restrictions.Eq("IdentityResourceId", id.Value))
                .List<IdentityClaim>()
                .Select(x => x.Type)
                .ToList();

            return identityResourceDto;
        }

        public PageList<IdentityResourceDto> GetIdentityResourceByPage(PageRequest page)
        {
            var criteria = this.Session.CreateCriteria<IdentityResource>()
                 .Add(Restrictions.Like("Name", page.Keywords.Trim(), MatchMode.Anywhere));


            var list = criteria.SetFirstResult(page.SetFirstResult())
                .SetMaxResults(page.GetMaxResults())
                .List<IdentityResource>()
                .ToList()
                .ToModel();
            int total = criteria.SetProjection(Projections.RowCount()).UniqueResult<int>();
            return new PageList<IdentityResourceDto>(list, total);
        }

        public void AddIdentityResource(IdentityResourceDto identityResourceDto)
        {
            var transaction = this.Session.BeginTransaction();
            try
            {

                var identityResource = identityResourceDto.ToEntity();
                this.Session.Save(identityResource);
                identityResourceDto.UserClaims.ForEach(claimType =>
                {
                    IdentityClaim identityClaim = new IdentityClaim();
                    identityClaim.IdentityResourceId = identityResource.Id;
                    identityClaim.Type = claimType;
                    this.Session.Save(identityClaim);
                });
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }



        public void DeleteIdentityResource(int id)
        {
            var identityResource = this.Session.Get<IdentityResource>(id);
            if (identityResource == null)
                return;
            var transaction = this.Session.BeginTransaction();
            try
            {
                this.Session.CreateQuery("delete from IdentityClaim where IdentityResourceId=:IdentityResourceId")
                    .SetInt32("IdentityResourceId", id)
                    .ExecuteUpdate();

                this.Session.Delete(identityResource);
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }



        public void UpdateIdentityResource(int id, IdentityResourceDto identityResourceDto)
        {
            var transaction = this.Session.BeginTransaction();
            try
            {
                var identityResource = this.Session.Get<IdentityResource>(id);
                identityResource = identityResourceDto.ToEntity(identityResource);
                this.Session.Update(identityResource);
                this.Session.CreateQuery("delete from IdentityClaim where IdentityResourceId=:IdentityResourceId")
                    .SetInt32("IdentityResourceId", id)
                    .ExecuteUpdate();
                identityResourceDto.UserClaims.ForEach(claimType =>
                {
                    IdentityClaim identityClaim = new IdentityClaim();
                    identityClaim.IdentityResourceId = identityResource.Id;
                    identityClaim.Type = claimType;
                    this.Session.Save(identityClaim);
                });
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }
        #endregion

        #region IdentityResourceProperty
        public List<IdentityPropertyDto> GetIdentityProperties(int identityResourceId)
        {
           return this.Session.CreateCriteria<IdentityProperty>()
                 .Add(Restrictions.Eq("IdentityResourceId", identityResourceId))
                 .AddOrder(Order.Asc("Key"))
                 .List<IdentityProperty>()
                 .ToList()
                 .ToModel();
        }
        public void DeleteIdentityProperty(int id)
        {
            var identityProperty = this.Session.Get<IdentityProperty>(id);
            if (identityProperty == null)
                return;
            var transaction = this.Session.BeginTransaction();
            try
            {
                this.Session.Delete(identityProperty);
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }
        public void AddIdentityProperty(IdentityPropertyDto identityPropertyDto)
        {
            var transaction = this.Session.BeginTransaction();
            try
            {
                var identityProperty = identityPropertyDto.ToEntity();
                this.Session.Save(identityProperty);
    
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public void UpdateIdentityProperty(int id, IdentityPropertyDto identityPropertyDto)
        {
            var transaction = this.Session.BeginTransaction();
            try
            {
                IdentityProperty identityProperty = this.Session.Get<IdentityProperty>(id);
                identityProperty = identityPropertyDto.ToEntity(identityProperty);
                this.Session.Update(identityProperty);
               
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public IdentityPropertyDto GetIdentityProperty(int? id)
        {
            IdentityPropertyDto identityPropertyDto = new IdentityPropertyDto();
            if (!id.HasValue && id.GetValueOrDefault() <= 0)
            {
                return identityPropertyDto;
            }
            IdentityProperty identityProperty = this.Session.Get<IdentityProperty>(id.Value);
            if (identityProperty == null)
            {
                return identityPropertyDto;
            }
            return identityProperty.ToModel();
        }
        #endregion
    }
}
