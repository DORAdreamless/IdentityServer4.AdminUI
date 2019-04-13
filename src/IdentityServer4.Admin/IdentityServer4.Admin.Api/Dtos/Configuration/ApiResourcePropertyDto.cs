namespace IdentityServer4.Admin.Api.Dtos.Configuration
{
    public class ApiPropertyDto
    {
        public int ApiResourceId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public class ApiPropertyListDto
    {
        public int Id { get; set; }
        public int ApiResourceId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}