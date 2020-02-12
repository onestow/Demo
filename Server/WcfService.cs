using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    [ServiceContract(SessionMode = SessionMode.Allowed)]
    public interface IService
    {
        [OperationContract]
        int Test();
    }

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class PerCallService : IService
    {
        class WcfInfo
        {
            public int CallTimes { get; set; } = 0;
            public IContextChannel Channel { get; set; }
        }
        static Dictionary<string, WcfInfo> clients = new Dictionary<string, WcfInfo>();
        static object thisLock = new object();
        int Cnt = 0;
        public int Test()
        {
            //Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss")}({Helper.GetRemoteIP(OperationContext.Current)}): {this.GetType().Name}");
            var ip = Helper.GetRemoteIP(OperationContext.Current);

            lock (thisLock)
            {
                if (!clients.ContainsKey(ip))
                    clients[ip] = new WcfInfo() { Channel = OperationContext.Current.Channel };
                clients[ip].CallTimes += 1;
            }

            OperationContext.Current.Channel.Faulted += (s, e) =>  Output(1);
            OperationContext.Current.Channel.Closed += (s, e) =>  Output(2);
            Output(3);
            return Cnt++;
        }

        void Output(int nt)
        {
            lock (thisLock)
            {
                Console.Write("\r                                               \r");
                Console.Write(string.Join(";\t", clients.Select(kv => $"{kv.Key}: {kv.Value.CallTimes}, {kv.Value.Channel.State}")));
            }
        }
    }

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class PerSessionService : IService
    {
        int Cnt = 0;
        public int Test()
        {
            Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss")}({Helper.GetRemoteIP(OperationContext.Current)}): {this.GetType().Name}");
            return Cnt++;
        }
    }

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class SingleService : IService
    {
        int Cnt = 0;
        public int Test()
        {
            Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss")}({Helper.GetRemoteIP(OperationContext.Current)}): {this.GetType().Name}");
            return Cnt++;
        }
    }
}
