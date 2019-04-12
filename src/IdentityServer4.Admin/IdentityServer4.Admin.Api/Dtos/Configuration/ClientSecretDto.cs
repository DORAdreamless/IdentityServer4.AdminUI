﻿using System;
using System.ComponentModel.DataAnnotations;

namespace IdentityServer4.Admin.Api.Dtos.Configuration
{
    public class ClientSecretDto
    {
        [Required]
        public string Type { get; set; } = "SharedSecret";

		public int Id { get; set; }

		public string Description { get; set; }

        [Required]
		public string Value { get; set; }

		public DateTime? Expiration { get; set; }
	}
}
