using FluentValidation.AspNetCore;
using IdentityServer4.Admin.Api.Entities;
using IdentityServer4.Admin.Api.Infrastructure.FluentValidation;
using IdentityServer4.Admin.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NHibernate.Mapping.ByCode;
using NHibernate.NetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace IdentityServer4.Admin.Api
{
    public static class AdminApiExtensions
    {
        private static bool IsMappingOf<T>(Type type)
        {
            return !type.IsGenericType && typeof(T).IsAssignableFrom(type);
        }

        private static void ConfigureNhibernate(ref NHibernate.Cfg.Configuration config)
        {
            var mapper = new ModelMapper();
            var assembly = Assembly.Load("IdentityServer4.Admin.Api");
            var list = assembly.GetExportedTypes().Where(x => !x.IsAbstract && IsMappingOf<IEntitySqlsMapper>(x));
            Console.WriteLine($"--------{list.Count()}-------");
            mapper.AddMappings(list);
            var domainMapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
            config.AddMapping(domainMapping);

        }

        public static IServiceCollection AddAdminApi(this IServiceCollection services, NHibernate.Cfg.Configuration config)
        {
            ConfigureNhibernate(ref config);
            services.AddHibernate(config);

            services.AddHttpContextAccessor();
            services.AddScoped<ClientService>();


            services.AddMvc()
            .AddFluentValidation(fv =>
            {
                fv.RegisterValidatorsFromAssembly(Assembly.Load("IdentityServer4.Admin.Api"));
                fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                fv.ImplicitlyValidateChildProperties = true;
            })
            .SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.AddTransient<IValidatorInterceptor, WebApiValidatorInterceptor>();

            return services;
        }

        public static void UseAdminApi(this IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.UseAsHibernateLoggerFactory();

            var sessionFactory = app.ApplicationServices.GetRequiredService<NHibernate.ISessionFactory>();
            var logger = loggerFactory.CreateLogger("AdminApi");
            logger.LogInformation("---Nhibernate 开始预热---");
            var session = sessionFactory.OpenSession();
            session.Get<Client>(1);
            sessionFactory.Close();
            logger.LogInformation("---Nhibernate 预热结束---");

        }
    }
}
