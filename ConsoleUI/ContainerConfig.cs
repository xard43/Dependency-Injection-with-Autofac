using Autofac;
using DemoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<BetterBusinessLogic>().As<IBusinessLogic>();
            
            builder.RegisterAssemblyTypes(Assembly.Load(nameof(DemoLibrary)))
                .Where( x=>x.Namespace.Contains("Utilities"))
                .As( x=>x.GetInterfaces().FirstOrDefault( y=> y.Name =="I" + x.Name)); 
            

            return builder.Build();
        }
    }
}
