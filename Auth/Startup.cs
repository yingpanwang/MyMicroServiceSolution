using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Auth.Configs.IdentityServer;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Common.IoC;
using DataProvider;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.PlatformAbstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using NLog.Extensions.Logging;
using Repositories;
using Auth.Extensions;

namespace Auth
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            #region 注入数据库上下文

            var connStr = Configuration.GetConnectionString("SQLServer");
            services.AddDbContextPool<AppDbContext>(opt =>
            {
                opt.UseLazyLoadingProxies();
                opt.UseSqlServer(connStr,c=>c.MigrationsAssembly("Auth"));
            });
            services.AddDbContextPool<UnitOfWork>(opt =>
            {
                opt.UseLazyLoadingProxies();
                opt.UseSqlServer(connStr);
            });

            #endregion

            #region Swagger

            services.AddSwaggerGen(opt=> 
            {
                opt.SwaggerDoc("AuthApi",new Swashbuckle.AspNetCore.Swagger.Info()
                {
                     Title = "AuthApi",
                     Version = "1.0"
                });
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath,"Auth.xml");
                opt.IncludeXmlComments(xmlPath);
            });

            #endregion

            #region IdentityServer

            services.AddIdentityServer()
              .AddDeveloperSigningCredential()
              .AddInMemoryIdentityResources(IdentityServerConfig.GetIdentityResourceResources())
              .AddInMemoryApiResources(IdentityServerConfig.GetApiResources())
              .AddInMemoryClients(IdentityServerConfig.GetClients())
              .AddResourceOwnerValidator<ResourceOwnerPasswordValidator>()
              .AddProfileService<ProfileService>();

            #endregion

            #region 跨域配置

            services.AddCors(opt =>
            {
                opt.AddPolicy("AllowAllOrigin", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials();
                });
            });

            #endregion

            #region 服务发现

            #endregion

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            return RegisterAutofac(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,IApplicationLifetime lifetime,IConfiguration configuration)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // 添加NLog
            loggerFactory.AddNLog();
            //app.RegisterConsul(lifetime, configuration);
            app.RegisterConsul(lifetime,configuration);
            app.UseStaticFiles();
            app.UseSwagger(c=>c.RouteTemplate = "{documentName}/swagger.json");
            app.UseSwaggerUI(c=> 
            {
                c.SwaggerEndpoint("/AuthApi/swagger.json", "AuthApi");
            });
            app.UseCors("AllowAllOrigin");
            app.UseIdentityServer();
            app.UseMvc();
        }


        private IServiceProvider RegisterAutofac(IServiceCollection services)
        {
            //实例化Autofac容器
            var builder = new ContainerBuilder();

            //将Services中的服务填充到Autofac中
            builder.Populate(services);
            //新模块组件注册
            DefaultModule.Configuration = Configuration;
            builder.RegisterModule<DefaultModule>();

            //创建容器
            var Container = builder.Build();
            //第三方IOC接管 core内置DI容器
            return new AutofacServiceProvider(Container);
        }
    }
}
