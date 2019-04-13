using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdentityServer4.Admin.Api.Dtos.Configuration
{
    public class ApiResourcePropertiesDto
    {
        public int ApiResourcePropertyId { get; set; }

        public int ApiResourceId { get; set; }

        public string ApiResourceName { get; set; }

        [Required]
        public string Key { get; set; }

        [Required]
        public string Value { get; set; }

        public List<ApiPropertyDto> ApiResourceProperties { get; set; } = new List<ApiPropertyDto>();

        public int TotalCount { get; set; }

        public int PageSize { get; set; }
    }
}
