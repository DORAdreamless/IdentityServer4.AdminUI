using IdentityServer4.Admin.Api.Dtos.Constants;
using IdentityServer4.Admin.Api.Enums;
using IdentityServer4.Admin.Api.Helpers;
using IdentityServer4.Admin.Api.Infrastructure.UI;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace IdentityServer4.Admin.Api.Dtos.Configuration
{
	public class ApiSecretDto
	{
      public  const string SharedSecret = "SharedSecret";
        public ApiSecretDto()
        {
           
            TypeList = new List<SelectItem>();
            TypeList.AddRange(ClientConsts.GetSecretTypes().Select(x => new SelectItem(x, x)));

            HashTypes = EnumHelpers.ToSelectList<HashType>();
        }

        public void HashApiSharedSecret()
        {
            if(this.Type== SharedSecret)
            {
                switch (Convert.ToInt32(this.HashType))
                {
                    case (int)Enums.HashType.Sha256:
                        this.Value = this.Value.Sha256();
                        break;
                    case (int)Enums.HashType.Sha512:
                        this.Value = this.Value.Sha512();
                        break;
                }
            }
        }
        [Required]
        public string Type { get; set; } = "SharedSecret";

        public string HashType { get; set; } = Convert.ToString((int)Enums.HashType.Sha256);

		public int ApiResourceId { get; set; }

		public string Description { get; set; }

	    [Required]
        public string Value { get; set; }

		public DateTime? Expiration { get; set; }

        public List<SelectItem> TypeList { get; set; }
        public List<SelectItem> HashTypes { get; set; }
    }

    public class ApiSecretListDto
    {

        public string Type { get; set; } = "SharedSecret";

        public int Id { get; set; }

        public string Description { get; set; }

        public string Value { get; set; }

        public DateTime? Expiration { get; set; }

        public DateTime Created { get; set; }
    }
}