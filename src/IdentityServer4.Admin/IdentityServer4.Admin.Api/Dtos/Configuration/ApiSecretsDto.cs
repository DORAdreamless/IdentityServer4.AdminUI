﻿using IdentityServer4.Admin.Api.Infrastructure.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdentityServer4.Admin.Api.Dtos.Configuration
{
	public class ApiSecretsDto
	{
		public ApiSecretsDto()
		{
			ApiSecrets = new List<ApiSecretDto>();
		}

		public int ApiResourceId { get; set; }

		public int ApiSecretId { get; set; }

	    public string ApiResourceName { get; set; }

        [Required]
		public string Type { get; set; } = "SharedSecret";

	    public List<SelectItem> TypeList { get; set; }

        public string Description { get; set; }

	    [Required]
        public string Value { get; set; }

		public string HashType { get; set; }

		public List<SelectItem> HashTypes { get; set; }

		public DateTime? Expiration { get; set; }

		public int TotalCount { get; set; }

		public int PageSize { get; set; }

		public List<ApiSecretDto> ApiSecrets { get; set; }
	}
}