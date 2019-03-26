using DockerServices.Cache.DTO;
using DockerServices.Cache.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockerServices.Cache.Provider.InMemory
{
    public class InMemoryProvider : ICacheProvider
    {
        private static Dictionary<string, CacheItem> items = new Dictionary<string, CacheItem>();

        public void Add(CacheItem item)
        {
            items.Add(item.Id, item);
        }

        public CacheItem Get(string key)
        {
            if (!items.Keys.Contains(key))
            {
                throw new ItemNotFoundException();
            }

            return items.Single(i => i.Key == key).Value;
        }

        public void Remove(string key)
        {
            if (items[key] == null)
            {
                throw new ItemNotFoundException();
            }

            items.Remove(key);
        }
    }
}
