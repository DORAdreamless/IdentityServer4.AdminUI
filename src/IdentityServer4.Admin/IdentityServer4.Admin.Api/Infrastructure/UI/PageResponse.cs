using System.Collections.Generic;

namespace IdentityServer4.Admin.Api.Infrastructure.UI
{
    public class PageResponse<T>
    {
        public PageResponse(IEnumerable<T> list, int total)
        {
            List = list;
            Total = total;
        }

        public IEnumerable<T> List { get; set; }

        public int Total { get; set; }

        public int TotalPage { get; set; }
    }
}
