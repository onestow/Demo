using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public interface ICallback
    {
        [OperationContract(IsOneWay = true)]
        void DisplayResult(string msg);
    }

    [ServiceContract(CallbackContract = typeof(ICallback))]
    public interface ICalculatorService
    {
        [OperationContract]
        void Add(double a, double b);
    }

    public class CalculatorService : ICalculatorService
    {
        public void Add(double a, double b)
        {
            OperationContext.Current.Channel.Faulted += (s, e) =>  Console.WriteLine($"(Faulted){DateTime.Now.ToString("HH:mm:ss")}Calc: {this.GetType().Name}");
            OperationContext.Current.Channel.Closed += (s, e) =>  Console.WriteLine($"(Closed){DateTime.Now.ToString("HH:mm:ss")}Calc: {this.GetType().Name}");

            var callback = OperationContext.Current.GetCallbackChannel<ICallback>();
            Console.WriteLine("正在计算中, 请稍候...");
            callback.DisplayResult("正在计算中, 请稍候...");
            Thread.Sleep(2000);
            Console.WriteLine($"计算完成: {a}+{b}={a + b}");
            callback.DisplayResult($"计算完成: {a}+{b}={a + b}");
        }
    }
}
