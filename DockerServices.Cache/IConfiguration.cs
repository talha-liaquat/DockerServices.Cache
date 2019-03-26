using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockerServices.Cache
{
    public interface IConfiguration
    {
        string AddUri { get; }

        string GetUri { get; }

        string RestUri { get; }
    }
}
