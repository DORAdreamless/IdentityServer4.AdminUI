using IdentityServer4.Admin.Api.Entities;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Api.Domains.Clients
{
    public class ClientMap : ClassMapping<Client>
    {
        public ClientMap()
        {
            this.Table("Clients");
            this.Id(x => x.Id, map =>
            {
                map.Generator(Generators.Identity);
            });
            this.Property(x => x.ClientId, map => {
                map.NotNullable(true);
                map.Length(200);
                map.Unique(true);

            });
            this.Property(x => x.ProtocolType, map => {
                map.NotNullable(true);
                map.Length(200);

            });
            this.Property(x => x.ClientName, map => {
                map.NotNullable(true);
                map.Length(200);
                map.Unique(true);

            });
            this.Property(x => x.ClientUri, map => {
                map.Length(2000);

            });
            this.Property(x => x.LogoUri, map => {
                map.Length(2000);

            });
            this.Property(x => x.Description, map => {
                map.Length(1000);

            });
            this.Property(x => x.FrontChannelLogoutUri, map => {
                map.Length(2000);

            });
            this.Property(x => x.BackChannelLogoutUri, map => {
                map.Length(2000);

            });
            this.Property(x => x.ClientClaimsPrefix, map => {
                map.Length(200);

            });
            this.Property(x => x.PairWiseSubjectSalt, map => {
                map.Length(200);

            });
            this.Property(x => x.UserCodeType, map => {
                map.Length(100);

            });
        }
    }
}
