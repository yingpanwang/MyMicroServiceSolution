using Autofac;
using DataProvider;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Text;
using Module = Autofac.Module;

namespace Common.IoC
{
    public class DefaultModule : Module
    {
        public static IConfiguration Configuration { get; set; }
        public DefaultModule()
        {
        }

        //重写Autofac管道Load方法，在这里注册注入
        protected override void Load(ContainerBuilder builder)
        {
            //注册Repository中的对象,Repository中的类要以Repository结尾，否则注册失败
            builder.RegisterAssemblyTypes(GetAssemblyByName("Repositories")).Where(a => a.Name.EndsWith("Repository")).AsImplementedInterfaces();
            
            //注册Service中的对象,Service中的类要以Service结尾，否则注册失败
            builder.RegisterAssemblyTypes(GetAssemblyByName("Services")).Where(a => a.Name.EndsWith("Service")).AsImplementedInterfaces();
        }
        /// <summary>
        /// 根据程序集名称获取程序集
        /// </summary>
        /// <param name="AssemblyName">程序集名称</param>
        /// <returns></returns>
        public static Assembly GetAssemblyByName(String AssemblyName)
        {
            return Assembly.Load(AssemblyName);
        }
    }
}
