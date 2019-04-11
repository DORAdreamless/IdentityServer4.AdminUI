using IdentityServer4.Admin.AspNetIdentity.DbContexts;
using IdentityServer4.Admin.AspNetIdentity.Interfaces;
using IdentityServer4.Admin.AspNetIdentity.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.AspNetIdentity.Configuration
{
    /// <summary>
    /// Extension methods to add EF database support to IdentityServer.
    /// </summary>
    public static class AspNetIdentityEntityFrameworkBuilderExtensions
    {
        /// <summary>
        /// Add Configuration DbContext to the DI system.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="storeOptionsAction">The store options action.</param>
        /// <returns></returns>
        public static IServiceCollection AddConfigurationDbContext(this IServiceCollection services,
            Action<ApplicationStoreOptions> storeOptionsAction = null)
        {
            return services.AddConfigurationDbContext<ApplicationDbContext>(storeOptionsAction);
        }

        /// <summary>
        /// Add Configuration DbContext to the DI system.
        /// </summary>
        /// <typeparam name="TContext">The IConfigurationDbContext to use.</typeparam>
        /// <param name="services"></param>
        /// <param name="storeOptionsAction">The store options action.</param>
        /// <returns></returns>
        public static IServiceCollection AddConfigurationDbContext<TContext>(this IServiceCollection services,
        Action<ApplicationStoreOptions> storeOptionsAction = null)
        where TContext : DbContext, IApplicationDbContext
        {
            var options = new ApplicationStoreOptions();
            services.AddSingleton(options);
            storeOptionsAction?.Invoke(options);

            if (options.ResolveDbContextOptions != null)
            {
                services.AddDbContext<TContext>(options.ResolveDbContextOptions);
            }
            else
            {
                services.AddDbContext<TContext>(dbCtxBuilder =>
                {
                    options.ConfigureDbContext?.Invoke(dbCtxBuilder);
                });
            }
            services.AddScoped<IApplicationDbContext, TContext>();

            return services;
        }
    }
    }
