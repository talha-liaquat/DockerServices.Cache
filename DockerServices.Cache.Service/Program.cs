using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace DockerServices.Cache.Service
{

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            var kernel = new StandardKernel();

            kernel.Load(Assembly.GetExecutingAssembly());

            var cacheService = kernel.Get<ICacheChannel>();

            //ServiceBase[] ServicesToRun;
            //ServicesToRun = new ServiceBase[]
            //{
            //    new CacheService()
            //};
            //ServiceBase.Run(ServicesToRun);

            new CacheService().RunAsConsole(null);
        }
    }
}
