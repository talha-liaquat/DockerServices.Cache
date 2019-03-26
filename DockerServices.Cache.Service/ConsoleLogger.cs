using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockerServices.Cache.Service
{
    class ConsoleLogger : ILogger
    {
        public void Debug(string message)
        {
            System.Console.WriteLine($"debug: {message}");
        }

        public void Debug(string message, params string[] args)
        {
            System.Console.WriteLine($"debug: {string.Format(message, args)}");
        }

        public void Error(Exception exception)
        {
            System.Console.WriteLine($"error: {exception.ToString()}");
        }

        public void Info(string message)
        {
            System.Console.WriteLine($"info: {message}");
        }

        public void Info(string message, params string[] args)
        {
            System.Console.WriteLine($"info: {string.Format(message, args)}");
        }
    }
}
