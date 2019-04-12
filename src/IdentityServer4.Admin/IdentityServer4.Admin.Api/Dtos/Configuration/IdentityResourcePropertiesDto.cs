using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdentityServer4.Admin.Api.Dtos.Configuration
{
    public class IdentityResourcePropertiesDto
    {
        public int IdentityResourcePropertyId { get; set; }

        public int IdentityResourceId { get; set; }

        public string IdentityResourceName { get; set; }

        [Required]
        public string Key { get; set; }

        [Required]
        public string Value { get; set; }

        public List<IdentityPropertyDto> IdentityResourceProperties { get; set; } = new List<IdentityPropertyDto>();

        public int TotalCount { get; set; }

        public int PageSize { get; set; }
    }
}
