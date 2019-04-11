using System;
using System.Text;

namespace IdentityServer4.Admin.Api.Infrastructure.UI
{
    public class PageRequest
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public string Sort { get; set; }

        public string Order { get; set; }

        public string Keywords { get; set; }

        public virtual NHibernate.ICriteria Criteria(ref NHibernate.ICriteria criteria)
        {
            return criteria;
        }
    }
}
