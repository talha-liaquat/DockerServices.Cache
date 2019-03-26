using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DockerServices.Cache.Channel.Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICacheWcfService" in both code and config file together.
    [ServiceContract]
    public interface ICacheWcfService
    {
        [OperationContract]
        [WebInvoke]
        void Push(DTO.CacheItem item);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        DTO.CacheItem Pull(string key);
    }
}
