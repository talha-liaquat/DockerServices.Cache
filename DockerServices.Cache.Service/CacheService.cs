using Ninject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace DockerServices.Cache.Service
{
    public partial class CacheService : ServiceBase
    {
        ICacheProvider provider;
        ICacheChannel channel;
        IConfiguration configuration;
        ILogger logger;

        public CacheService()
        {
            var kernel = new StandardKernel();

            kernel.Load(Assembly.GetExecutingAssembly());

            this.provider = kernel.Get<ICacheProvider>();
            this.channel = kernel.Get<ICacheChannel>();
            this.configuration = kernel.Get<IConfiguration>();
            this.logger = kernel.Get<ILogger>();

            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            channel.Start();
        }

        protected override void OnStop()
        {
            channel.Stop();
        }

        public void RunAsConsole(string[] args)
        {
            OnStart(args);
            Console.WriteLine("Started, press any key to exit!");
            Console.Read();
            OnStart(args);
        }
    }
}
