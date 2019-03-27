using DockerServices.Cache.Channel.Wcf;
using DockerServices.Cache.Channel.ZeroMQ;
using DockerServices.Cache.Provider.InMemory;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockerServices.Cache.Console
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<ICacheProvider>().To<InMemoryProvider>();

            Bind<ICacheChannel>().To<WcfChannel>();

            Bind<IConfiguration>().To<AppConfiguration>();

            Bind<ILogger>().To<ConsoleLogger>();
        }
    }
}
