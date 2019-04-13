using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;

namespace IdentityServer4.Admin.Api.Dtos.Requests
{
   public class ClientPageRequest :Infrastructure.UI.PageRequest
    {
        public override ICriteria PrepareCriteria(ref ICriteria criteria)
        {
            if (!string.IsNullOrWhiteSpace(this.Keywords))
                criteria.Add(NHibernate.Criterion.Restrictions.Like("ClientName", this.Keywords.Trim(), NHibernate.Criterion.MatchMode.Anywhere));
            return base.PrepareCriteria(ref criteria);
        }

        public override ICriteria PrepareOrder(ref ICriteria criteria)
        {
            criteria.AddOrder(NHibernate.Criterion.Order.Asc("ClientName"));
            return base.PrepareOrder(ref criteria);
        }
    }
}
