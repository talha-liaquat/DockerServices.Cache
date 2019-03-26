using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockerServices.Cache
{
    public interface ILogger
    {
        void Error(Exception exception);

        void Info(string message);

        void Info(string message, params string[] args);

        void Debug(string message);

        void Debug(string message, params string[] args);
    }
}
