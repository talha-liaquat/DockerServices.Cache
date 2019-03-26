using DockerServices.Cache.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroMQ;

namespace DockerServices.Cache.Console.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var keys = new List<string>();
            using (var requester = new ZSocket(ZSocketType.PUSH))
            {
                requester.Connect("tcp://127.0.0.1:5556");

                for (int n = 0; n < 10; ++n)
                {

                    var cacheItem = new CacheItem { Id = Guid.NewGuid().ToString(), Data = $"Item {n}" };
                    keys.Add(cacheItem.Id);
                    requester.Send(new ZFrame(cacheItem.ToByteArray()));
                }

            }

            using (var requester = new ZSocket(ZSocketType.REQ))
            {
                requester.Connect("tcp://127.0.0.1:5555");

                foreach(var key in keys)
                {

                    // Send
                    requester.Send(new ZFrame(key));

                    // Receive
                    using (ZFrame reply = requester.ReceiveFrame())
                    {
                        var cacheItem = reply.Read().ToObject<DTO.CacheItem>();

                        System.Console.WriteLine(" Received: {0} {1}!", cacheItem.Id, cacheItem.Data.ToString());
                    }
                }

                System.Console.Read();
            }
        }
    }
}
