using IdentityServer4.EntityFramework.Entities;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Api.Repositories
{
    public class ClientMap : ClassMapping<Client>
    {
        public ClientMap()
        {
            this.Id(x => x.Id, map =>
            {
               // map.Generator()
              
            });
            this.Property(x => x.ClientId, map => {
                map.NotNullable(true);
                map.Length(40);
                map.Unique(true);
               
            });
        }
    }
}
