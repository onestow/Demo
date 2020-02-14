using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //StartHeartBeat();

            Task.Run(() =>
            {
                //new CallBackService.CalculatorServiceClient(new System.ServiceModel.InstanceContext(new CalcCallback(this))).Add(2, 3);
            });
        }

        #region 调用时创建连接
        private void btnPerHit_Click(object sender, EventArgs e)
        {
            using (var client = new PerCallService.ServiceClient())
            {
                var res = client.Test();
                tbPerCall.Text = res.ToString();
            }
            //Thread.Sleep(3000);
            //using (var client = new PerSessionService.ServiceClient())
            //{
            //    var res = client.Test();
            //    tbPerSession.Text = res.ToString();
            //}
            //Thread.Sleep(3000);
            //using (var client = new SingleService.ServiceClient())
            //{
            //    var res = client.Test();
            //    tbSingle.Text = res.ToString();
            //}
        }
        #endregion

        #region 启动时创建连接
        PerCallService.ServiceClient pcClient = new PerCallService.ServiceClient();
        PerSessionService.ServiceClient psClient = new PerSessionService.ServiceClient();
        SingleService.ServiceClient sClient = new SingleService.ServiceClient();
        private void btnStart_Click(object sender, EventArgs e)
        {
            pcClient.InnerChannel.Faulted += (s, ea) => MessageBox.Show("Faulted");
            pcClient.InnerChannel.Closed += (s, ea) => MessageBox.Show("Closed");
            tbPerCall2.Text = pcClient.Test().ToString();
            tbPerSession2.Text = psClient.Test().ToString();
            tbSingle2.Text = sClient.Test().ToString();
        }

        #endregion

        #region maxcall测试
        static int CallCnt = 5;
        string[] MaxCallMsgs = new string[CallCnt];
        private void btnMaxCall_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                var listThread = new List<Thread>();
                for (int i = 0; i < CallCnt; i++)
                {
                    var t = RunThread(i);
                    listThread.Add(t);
                }

                foreach (var t in listThread)
                    t.Join();
            });
        }

        private Thread RunThread(int no)
        {
            MaxCallMsgs[no] = "";
            var t = new Thread(new ParameterizedThreadStart((obj) =>
            {
                Output($"{no} 开始执行", no);
                using (var client = new PerCallService.ServiceClient())
                {
                    var watch = Stopwatch.StartNew();
                    var a = client.Test();
                    watch.Stop();
                    Output($"执行完成, 返回值为 {a},用时 {watch.ElapsedMilliseconds} ms", no);
                }
            }));
            t.Start(no);
            t.IsBackground = true;
            return t;
        }

        private void Output(string msg, int no)
        {
            MaxCallMsgs[no] += $"{msg} ---- ";

            if (tbMaxCall.InvokeRequired)
                tbMaxCall.Invoke(new Action<string>((obj) => tbMaxCall.Text = obj), string.Join(Environment.NewLine, MaxCallMsgs));
            else
                tbMaxCall.Text = string.Join(Environment.NewLine, MaxCallMsgs);
        }
        #endregion

        #region heartbeat
        PerCallService.ServiceClient heartbeatClient = new PerCallService.ServiceClient();
        void StartHeartBeat()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    try
                    {
                        if (heartbeatClient.State != System.ServiceModel.CommunicationState.Opened)
                            heartbeatClient.Open();
                        heartbeatClient.Test();
                    }
                    catch (Exception exo)
                    {
                        Log("", exo);
                        try
                        {
                            heartbeatClient = new PerCallService.ServiceClient();
                            heartbeatClient.Open();
                        }
                        catch (Exception ex)
                        {
                            Log("重试失败: ", ex);
                        }
                    }
                    Thread.Sleep(1000);
                }
            });
        }
        #endregion
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //pcClient.Close();
                //psClient.Close();
                //sClient.Close();
                //heartbeatClient.Close();
            }
            catch
            { }
        }

        public void Log(string msg)
        {
            if (tbMsg.InvokeRequired)
                tbMsg.Invoke(new Action<string>((obj) => Log(obj)), msg);
            else
                tbMsg.AppendText(DateTime.Now.ToString("HHmmssfff") + ": " + msg + Environment.NewLine);
        }

        void Log(string msg, Exception ex, int line = 2)
        {
            var errMsg = ex.ToString().Split('\n');
            Log(msg + string.Join(" ", errMsg.Take(line)));
        }
    }
    class CalcCallback : CallBackService.ICalculatorServiceCallback
    {
        private Form1 f;
        public CalcCallback(Form1 f)
        {
            this.f = f;
        }
        public void DisplayResult(string msg)
        {
            f.Log(msg);
        }
    }
}
