using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var hosts = new List<ServiceHost>();

            hosts.Add(TryOpen(typeof(PerCallService)));
            hosts.Add(TryOpen(typeof(PerSessionService)));
            hosts.Add(TryOpen(typeof(SingleService)));
            //hosts.Add(TryOpen(typeof(CalculatorService)));


            Console.WriteLine("任意键结束...");
            Console.ReadKey(true);

            foreach (var host in hosts)
                TryClose(host);
        }

        static ServiceHost TryOpen(Type serviceType)
        {
            try
            {
                var host = new ServiceHost(serviceType);
                host.Open();
                Console.WriteLine($"{serviceType.Name}启动成功");
                return host;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{serviceType.Name}启动异常: {ex}");
                return null;
            }
        }

        static bool TryClose(ServiceHost host)
        {
            try
            {
                host?.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
