using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using IdentityServer4.Admin.Api;
using IdentityServer4.Admin.Api.Infrastructure.FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NHibernate;
using ILoggerFactory = Microsoft.Extensions.Logging.ILoggerFactory;
using NHibernate.Cfg;

namespace IdentityServer4.Admin.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvcCore()
                        .AddAuthorization()
                        .AddJsonFormatters();

            services.AddAuthentication("Bearer")
     .AddJwtBearer("Bearer", options =>
     {
         options.Authority = "http://localhost:5000";
         options.RequireHttpsMetadata = false;

         options.Audience = "api1";
     });

            services.AddCors(options =>
            {
                // this defines a CORS policy called "default"
                options.AddPolicy("default", policy =>
                {
                    policy.WithOrigins("http://localhost:5003")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            NHibernate.Cfg.Configuration config = new NHibernate.Cfg.Configuration();
            config.DataBaseIntegration(options=>
            {
                options.ConnectionString = Configuration.GetConnectionString("DefaultConnection");
                options.Driver<NHibernate.Driver.SqlClientDriver>();
                options.Dialect<NHibernate.Dialect.MsSql2008Dialect>();
                options.LogSqlInConsole = true;
                options.LogFormattedSql = true;
                options.ConnectionReleaseMode = ConnectionReleaseMode.OnClose;
                options.SchemaAction = SchemaAutoAction.Update;
                options.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
            });
            services.AddAdminApi(config);
       
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCors("default");
            app.UseAuthentication();
            app.UseAdminApi(loggerFactory);
            // app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
