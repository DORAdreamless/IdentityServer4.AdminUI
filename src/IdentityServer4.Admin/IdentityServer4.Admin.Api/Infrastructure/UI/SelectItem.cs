using Newtonsoft.Json;

namespace IdentityServer4.Admin.Api.Infrastructure.UI
{
    public class SelectItem
    {
        public SelectItem(object value,string label)
        {
            Label = label;
            Value = value;
        }

        [JsonProperty("label")]
        public string Label { get; set; }
        [JsonProperty("value")]
        public object Value { get; set; }
    }
}
