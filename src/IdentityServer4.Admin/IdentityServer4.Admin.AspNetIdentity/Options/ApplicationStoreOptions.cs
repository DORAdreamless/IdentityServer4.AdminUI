using Microsoft.EntityFrameworkCore;
using System;

namespace IdentityServer4.Admin.AspNetIdentity.Options
{
    public class ApplicationStoreOptions
    {
        /// <summary>
        /// Callback to configure the EF DbContext.
        /// </summary>
        /// <value>
        /// The configure database context.
        /// </value>
        public Action<DbContextOptionsBuilder> ConfigureDbContext { get; set; }

        /// <summary>
        /// Callback in DI resolve the EF DbContextOptions. If set, ConfigureDbContext will not be used.
        /// </summary>
        /// <value>
        /// The configure database context.
        /// </value>
        public Action<IServiceProvider, DbContextOptionsBuilder> ResolveDbContextOptions { get; set; }

        /// <summary>
        /// Gets or sets the default schema.
        /// </summary>
        /// <value>
        /// The default schema.
        /// </value>
        public string DefaultSchema { get; set; } = null;
        /// <summary>
        /// Gets or sets the identity resource table configuration.
        /// </summary>
        /// <value>
        /// The identity resource.
        /// </value>
        public TableConfiguration IdentityResource { get; set; } = new TableConfiguration("IdentityResources");
    }
}
