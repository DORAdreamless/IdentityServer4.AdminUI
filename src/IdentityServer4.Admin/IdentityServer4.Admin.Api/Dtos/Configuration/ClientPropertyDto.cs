namespace IdentityServer4.Admin.Api.Dtos.Configuration
{
    public class ClientPropertyDto
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public class ClientPropertyListDto
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}