using DockerServices.Cache.Channel.ZeroMQ;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DockerServices.Cache.Console
{
    class Program
    {
        ICacheChannel channel;
        ILogger logger;

        public Program()
        {
            var kernel = new StandardKernel();

            kernel.Load(Assembly.GetExecutingAssembly());

            this.channel = kernel.Get<ICacheChannel>();
            this.logger = kernel.Get<ILogger>();
        }

        static void Main(string[] args)
        {
            var program = new Program();

            program.logger.Info("Starting...");
            program.channel.Start();
            System.Console.ReadLine();
        }
    }
}
