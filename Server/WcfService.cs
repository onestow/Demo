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
        int Cnt = 0;
        public int Test()
        {
            var ip = Helper.GetRemoteIP(OperationContext.Current);
            Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss")}({ip}): {this.GetType().Name}");
            OperationContext.Current.Channel.Faulted += (s, e) =>  Console.WriteLine($"(Faulted){DateTime.Now.ToString("HH:mm:ss")}({ip}): {this.GetType().Name}");
            OperationContext.Current.Channel.Closed += (s, e) =>  Console.WriteLine($"(Closed){DateTime.Now.ToString("HH:mm:ss")}({ip}): {this.GetType().Name}");
            return Cnt++;
        }
    }

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class PerSessionService : IService
    {
        int Cnt = 0;
        public int Test()
        {
            var ip = Helper.GetRemoteIP(OperationContext.Current);
            Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss")}({ip}): {this.GetType().Name}");
            OperationContext.Current.Channel.Faulted += (s, e) =>  Console.WriteLine($"(Faulted){DateTime.Now.ToString("HH:mm:ss")}({ip}): {this.GetType().Name}");
            OperationContext.Current.Channel.Closed += (s, e) =>  Console.WriteLine($"(Closed){DateTime.Now.ToString("HH:mm:ss")}({ip}): {this.GetType().Name}");
            return Cnt++;
        }
    }

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class SingleService : IService
    {
        int Cnt = 0;
        public int Test()
        {
            var ip = Helper.GetRemoteIP(OperationContext.Current);
            Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss")}({ip}): {this.GetType().Name}");
            OperationContext.Current.Channel.Faulted += (s, e) =>  Console.WriteLine($"(Faulted){DateTime.Now.ToString("HH:mm:ss")}({ip}): {this.GetType().Name}");
            OperationContext.Current.Channel.Closed += (s, e) =>  Console.WriteLine($"(Closed){DateTime.Now.ToString("HH:mm:ss")}({ip}): {this.GetType().Name}");
            return Cnt++;
        }
    }
}
