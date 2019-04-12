using NHibernate.Criterion;
using System;
using System.Text;

namespace IdentityServer4.Admin.Api.Infrastructure.UI
{
    public class PageRequest
    {
        public int Page { get; set; } = 1;

        public int Rows { get; set; } = 10;

        public string Sort { get; set; } = string.Empty;

        public string Order { get; set; } = string.Empty;

        public string Keywords { get; set; } = string.Empty;

        const string Asc = "asc";

        const string Desc = "desc";

        public virtual NHibernate.ICriteria PrepareCriteria(ref NHibernate.ICriteria criteria)
        {
            if (!string.IsNullOrWhiteSpace(this.Keywords))
                criteria.Add(Restrictions.Like("Name", this.Keywords.Trim(), MatchMode.Anywhere));

            return criteria;
        }
        public virtual NHibernate.ICriteria PrepareOrder(ref NHibernate.ICriteria criteria)
        {
            if (this.IsClientSort())
            {
                criteria.ClearOrders();
                if (string.Compare(this.Order.Trim(), Asc, true) == 0)
                    criteria.AddOrder(NHibernate.Criterion.Order.Asc(this.Sort.Trim()));
                if (string.Compare(this.Order.Trim(), Desc, true) == 0)
                    criteria.AddOrder(NHibernate.Criterion.Order.Desc(this.Sort.Trim()));
            }

            return criteria;
        }
        public int GetFirstResult()
        {
            return (this.Page - 1) * this.Rows;
        }

        public int GetMaxResults()
        {
            return this.Page * this.Rows;
        }

        public bool IsClientSort()
        {
            if (string.IsNullOrWhiteSpace(this.Order))
                return false;
            if (string.IsNullOrWhiteSpace(this.Sort))
                return false;
            if (string.Compare(this.Sort.Trim(), Asc, true) == 0)
                return true;
            if (string.Compare(this.Sort.Trim(), Desc, true) == 0)
                return true;
            return false;
        }
    }
}
