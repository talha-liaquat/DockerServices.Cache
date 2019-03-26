using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DockerServices.Cache.DTO;

namespace DockerServices.Cache.Channel.Wcf
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    public class CacheWcfService : ICacheWcfService
    {
        ICacheProvider provider;

        public CacheWcfService(ICacheProvider provider)
        {
            this.provider = provider;
        }       

        public CacheItem Pull(string key)
        {
            return provider.Get(key);
        }

        public void Push(CacheItem item)
        {
            provider.Add(item);
        }

        public string Test()
        {
            return "test";
        }
    }
}
