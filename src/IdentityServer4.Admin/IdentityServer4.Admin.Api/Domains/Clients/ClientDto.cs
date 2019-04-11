using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IdentityServer4.Admin.Api.Domains.Clients
{

    public class ClientDto
    {
        public string ClientId { get; set; }

        public string ClientName { get; set; }

        public string Description { get; set; }

        public string ClientUri { get; set; }

        public string LogoUri { get; set; }

    }
}
