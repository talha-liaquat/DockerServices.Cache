using DockerServices.Cache.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockerServices.Cache
{
    public interface ICacheProvider
    {
        void Add(CacheItem item);

        CacheItem Get(string key);

        void Remove(string key);
    }
}
