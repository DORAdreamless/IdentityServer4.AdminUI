namespace IdentityServer4.Admin.Api.Infrastructure.UI
{
    public class SelectItem
    {
        public SelectItem(string label, string text)
        {
            Label = label;
            Text = text;
        }

        public string Label { get; set; }

        public string Text { get; set; }
    }
}
