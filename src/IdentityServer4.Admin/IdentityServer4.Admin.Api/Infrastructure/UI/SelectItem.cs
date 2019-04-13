using Newtonsoft.Json;

namespace IdentityServer4.Admin.Api.Infrastructure.UI
{
    public class SelectItem
    {
        public SelectItem( string value,string label)
        {
            Label = label;
            Value = value;
        }

        [JsonProperty("label")]
        public string Label { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
