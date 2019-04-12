using System;
using System.Text;

namespace IdentityServer4.Admin.Api.Infrastructure.UI
{
    public class PageRequest
    {
        public int PageIndex { get; set; } = 1;

        public int PageSize { get; set; } = 10;

        public string Sort { get; set; } = string.Empty;

        public string Order { get; set; } = string.Empty;

        public string Keywords { get; set; } = string.Empty;

        public virtual NHibernate.ICriteria Criteria(ref NHibernate.ICriteria criteria)
        {
            return criteria;
        }

        public int SetFirstResult()
        {
            return (this.PageIndex - 1) * this.PageSize;
        }

        public int GetMaxResults()
        {
            return this.PageIndex  * this.PageSize;
        }
    }
}
