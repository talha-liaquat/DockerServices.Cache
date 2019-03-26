using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockerServices.Cache
{
    public sealed class AppConfiguration : IConfiguration
    {
        public string AddUri => System.Configuration.ConfigurationManager.AppSettings["AddUri"];

        public string GetUri => System.Configuration.ConfigurationManager.AppSettings["GetUri"];

        public string RestUri => System.Configuration.ConfigurationManager.AppSettings["RestUri"];
    }
}
