﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Consul;
using Ocelot.ServiceDiscovery;
using Polly;
using Ocelot.Provider.Polly;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Http;
using Ocelot.Provider.Consul;

namespace ApiGateway
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
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("ApiGateway", new Swashbuckle.AspNetCore.Swagger.Info()
                {
                    Title = "ApiGateway",
                    Version = "1.0"
                });
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "ApiGateway.xml");
                opt.IncludeXmlComments(xmlPath);
            });

            //Action<IdentityServerAuthenticationOptions> id4ServiceAuthOpt = options => 
            //{
            //    options.Authority = "http://localhost:64889";
            //    options.RequireHttpsMetadata = false;
            //    options.ApiName = "api1";
            //    options.SupportedTokens = SupportedTokens.Both;
            //};
            services
                .AddAuthentication("IdentityBearer")
                .AddIdentityServerAuthentication("IdentityBearer", opt=> 
                {
                    opt.Authority = "http://localhost:64889";
                    opt.RequireHttpsMetadata = false;
                    opt.ApiName = "api1";
                    opt.SupportedTokens = SupportedTokens.Both;
                });
            #region 跨域配置

            services.AddCors(opt =>
            {
                opt.AddPolicy("AllowAllOrigin", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials();
                });
            });

            #endregion
            
            services
                .AddOcelot(Configuration)
                .AddConsul()
                .AddPolly();
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                string[] apis = { "AuthApi","WebClient1"};
                apis.ToList().ForEach(key=> 
                {
                    c.SwaggerEndpoint($"/{key}/swagger.json", key);
                });
                c.DocumentTitle = "网关";
               
            });
            app.UseAuthentication();
            app.UseCors("AllowAllOrigin");
            app.UseOcelot().Wait();
            app.UseMvc();
        }
    }
}
