using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Helper
    {
        public static string GetRemoteIP(System.ServiceModel.OperationContext context)
        {
            var addrInfo = context.IncomingMessageProperties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
            return addrInfo?.Address + ":" + addrInfo?.Port;
        }
    }
}
