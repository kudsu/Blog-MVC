using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;

using Autofac.Integration.Mvc;

using System.Web.Mvc;

namespace Sober.Web
{
    public  class AutofacConfig
    {
        public static void RegisterDenpendency()
        {
            //1、创建容器配置对象
            var builder = new ContainerBuilder();
            //2、注册所有的控制器到我们的容器（利用反射，就是在执行期间动态获取我们的程序里的代码）
          //  builder.RegisterType<HomeController>().PropertiesAutowired();
            builder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();

          //3、加载其他项目的程序集
            var service = Assembly.Load("Sober.Service");
            var repository = Assembly.Load("Sober.Repository");
            //4、注册实现方的程序集里的类，到我们的容器（利用反射，自动扫描里面所有的符合标准的类，并且自动注册）
            //实现方必须以  实现接口形式注册（AsImplementedInterfaces）
            builder.RegisterAssemblyTypes(service).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(repository).Where(t=>t.Name.EndsWith("Repository")).AsImplementedInterfaces();
            //5、创建容器
            var container = builder.Build();

            //6、替换掉MVC内置的 控制器实例化的功能，改成由autufac来实现的控制器实例化的功能
            //他会自动的扫描，控制器需要使用到的S而vice，然后从已注册的容器里面找到对应的已实现的service
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
          }
     
    }
}