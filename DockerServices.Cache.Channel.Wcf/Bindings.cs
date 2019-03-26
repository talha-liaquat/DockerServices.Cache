using DockerServices.Cache.Provider.InMemory;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockerServices.Cache.Channel.Wcf
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<ICacheProvider>().To<InMemoryProvider>();

            Bind<ICacheWcfService>().To<CacheWcfService>();
        }
    }
}
