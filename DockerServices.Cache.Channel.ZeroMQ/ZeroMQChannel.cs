using DockerServices.Cache.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZeroMQ;

namespace DockerServices.Cache.Channel.ZeroMQ
{
    public class ZeroMQChannel : ICacheChannel
    {
        ICacheProvider provider;
        IConfiguration configuration;
        ILogger logger;

        public ZeroMQChannel(ICacheProvider provider, IConfiguration configuration, ILogger logger)
        {
            this.provider = provider;
            this.configuration = configuration;
            this.logger = logger;
        }

        public void Start()
        {
            new Thread(() => PullSocket()).Start();
            new Thread(() => ResponseSocket()).Start();
        }

        public void Stop()
        {
        }

        private void PullSocket()
        {
            using (var responder = new ZSocket(ZSocketType.PULL))
            {
                responder.Bind(configuration.AddUri);
                logger.Info("PullSocket Started");

                while (true)
                {
                    using (ZFrame request = responder.ReceiveFrame())
                    {
                        var cacheItem = request.Read().ToObject<DTO.CacheItem>();

                        logger.Debug($"Received {cacheItem.Id}");

                        Thread.Sleep(1);

                        try
                        {
                            provider.Add(cacheItem);
                        }
                        catch (ItemNotFoundException ex)
                        {
                            logger.Error(ex);
                        }
                    }
                }
            }
        }

        private void ResponseSocket()
        {
            using (var responder = new ZSocket(ZSocketType.REP))
            {
                responder.Bind(configuration.GetUri);
                logger.Info("ResponseSocket Started");

                while (true)
                {
                    using (ZFrame request = responder.ReceiveFrame())
                    {
                        var key = request.ReadString();

                        logger.Debug($"Received {key}");

                        Thread.Sleep(1);

                        DTO.CacheItem item = null;

                        try
                        {
                            item = provider.Get(key);
                        }
                        catch (ItemNotFoundException ex)
                        {
                            logger.Error(ex);
                        }

                        responder.Send(new ZFrame(item.ToByteArray()));
                    }
                }
            }
        }
    }
}
