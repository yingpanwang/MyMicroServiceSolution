
using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Extensions
{
    /// <summary>
    /// 服务配置信息
    /// </summary>
    public class ServiceOptions 
    {
        /// <summary>
        /// 服务ip
        /// </summary>
        public string ServiceIP { get; set; }

        /// <summary>
        /// 服务名称
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// 协议类型http or https
        /// </summary>
        public string Scheme { get; set; } = "http";

        /// <summary>
        /// 端口
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// 健康检查接口
        /// </summary>
        public string HealthCheckUrl { get; set; } = "/api/values";

        /// <summary>
        /// 健康检查间隔时间
        /// </summary>
        public int HealthCheckIntervalSecond { get; set; } = 10;

        /// <summary>
        /// consul配置信息
        /// </summary>
        public ConsulOptions ConsulOptions { get; set; }
    }

    /// <summary>
    /// consul配置信息
    /// </summary>
    public class ConsulOptions 
    {
        /// <summary>
        /// consul ip
        /// </summary>
        public string ConsulIP { get; set; }

        /// <summary>
        /// consul 端口
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// 协议类型http or https
        /// </summary>
        public string Scheme { get; set; } = "http";
    }

    /// <summary>
    /// consul扩展
    /// </summary>
    public static class ConsulExtensions
    {
        private static ServiceOptions serviceOptions = new ServiceOptions ();

        /// <summary>
        /// 注册consul
        /// </summary>
        public static void RegisterConsul(this IApplicationBuilder app, IApplicationLifetime life, IConfiguration configuration)
        {
            configuration.GetSection("ServiceOptions").Bind(serviceOptions);
            if (serviceOptions == null)
            {
                throw new Exception("获取服务注册信息失败!请检查配置信息是否正确!");
            }
            Register(life);
        }

        /// <summary>
        /// 注册consul
        /// </summary>
        /// <param name="app"></param>
        /// <param name="life">引用生命周期</param>
        /// <param name="options">配置参数</param>
        public static void RegisterConsul(this IApplicationBuilder app, IApplicationLifetime life, Action<ServiceOptions> options) 
        {
            options.Invoke(serviceOptions);
            Register(life);
        }

        private static void Register(IApplicationLifetime life) 
        {
            // 程序开始时注册服务
            life.ApplicationStarted.Register(() =>
            {
                if (serviceOptions == null)
                {
                    throw new Exception("获取服务注册信息失败!请检查配置信息是否正确!");
                }
                string consulAddress = $"{serviceOptions.Scheme}://{serviceOptions.ConsulOptions.ConsulIP}:{serviceOptions.ConsulOptions.Port}";

                var consulClient = new ConsulClient(opt =>
                {
                    opt.Address = new Uri(consulAddress);
                });

                var httpCheck = new AgentServiceCheck()
                {
                    DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(10), // 服务启动多久后注册
                    Interval = TimeSpan.FromSeconds(serviceOptions.HealthCheckIntervalSecond), // 间隔
                    HTTP = $"{serviceOptions.Scheme}://{serviceOptions.ServiceIP}:{serviceOptions.Port}{serviceOptions.HealthCheckUrl}",
                    Timeout = TimeSpan.FromSeconds(10)
                };

                var registration = new AgentServiceRegistration()
                {
                    Checks = new[] { httpCheck },
                    ID = Guid.NewGuid().ToString(),
                    Name = serviceOptions.ServiceName,
                    Address = $"{serviceOptions.Scheme}://{serviceOptions.ServiceIP}",
                    Port = serviceOptions.Port,
                };

                consulClient.Agent.ServiceRegister(registration).Wait();


                life.ApplicationStopping.Register(() =>
                {
                    consulClient.Agent.ServiceDeregister(registration.ID).Wait();
                });
            });
        }
    }
}
