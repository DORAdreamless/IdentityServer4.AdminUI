namespace IdentityServer4.Admin.Api.Dtos.Configuration
{
    public class IdentityPropertyDto
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public int IdentityResourceId { get; set; }
    }
}