using IdentityServer4.Admin.Api.Infrastructure.UI;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Api.Dtos.Requests
{
   public class ApiScopePageRequest: PageRequest
    {
        public override ICriteria PrepareCriteria(ref ICriteria criteria)
        {
            if (!string.IsNullOrWhiteSpace(this.Keywords))
                criteria.Add(Restrictions.Like("Name", this.Keywords.Trim(), MatchMode.Anywhere));
            return base.PrepareCriteria(ref criteria);
        }

        public override ICriteria PrepareOrder(ref ICriteria criteria)
        {
            criteria.AddOrder(NHibernate.Criterion.Order.Asc("Name"));
            return base.PrepareOrder(ref criteria);
        }
    }
}
