﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IdentityServer4.Admin.Api.Infrastructure.UI;
namespace IdentityServer4.Admin.Api.Dtos.Configuration
{
	public class ClientSecretsDto
	{
		public ClientSecretsDto()
		{
			ClientSecrets = new List<ClientSecretDto>();
		}

		public int ClientId { get; set; }

	    public string ClientName { get; set; }

		public int ClientSecretId { get; set; }

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

		public List<ClientSecretDto> ClientSecrets { get; set; }
	}
}