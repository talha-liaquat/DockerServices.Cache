using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockerServices.Cache.DTO
{
    [Serializable]
    public class CacheItem
    {
        public string Id { get; set; }
        public object Data { get; set; }
    }
}
