using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace DockerServices.Cache.Channel.Wcf
{
    public class WcfChannel : ICacheChannel
    {
        ICacheProvider provider;
        IConfiguration configuration;
        ILogger logger;
        WebServiceHost host;

        public WcfChannel(ICacheProvider provider, IConfiguration configuration, ILogger logger)
        {
            this.provider = provider;
            this.configuration = configuration;
            this.logger = logger;
        }

        public void Start()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            host = new WebServiceHost(kernel.Get<ICacheWcfService>(), new Uri(configuration.RestUri));

            ServiceEndpoint ep = host.AddServiceEndpoint(typeof(ICacheWcfService), new WebHttpBinding(), "");
            ServiceDebugBehavior stp = host.Description.Behaviors.Find<ServiceDebugBehavior>();

            stp.HttpHelpPageEnabled = false;
            host.Open();

            logger.Debug($"Service is up and running at {configuration.RestUri}");
        }

        public void Stop()
        {
            host?.Close();
        }
    }
}
