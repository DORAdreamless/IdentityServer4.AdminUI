using Newtonsoft.Json;
using System.Collections.Generic;

namespace IdentityServer4.Admin.Api.Infrastructure.UI
{
    public class PageList<T>
    {
        public PageList(IEnumerable<T> list, int total)
        {
            List = list;
            Total = total;
        }
        [JsonProperty("list")]
        public IEnumerable<T> List { get; set; }
        [JsonProperty("total")]
        public int Total { get; set; }
        [JsonProperty("totalPage")]
        public int TotalPage { get; set; }
    }
}
