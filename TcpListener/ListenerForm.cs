using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace PortListener
{
    public partial class ListenerForm : Form
    {
        public ListenerForm()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;

            textBox1.Text = "Server|Client";
            comboBox1.SelectedIndex = 2;
            dataGridView1.DataSource = new List<ConnInfo>();

            Task.Run(() =>
            {
                while (true)
                {
                    var connInfos = GetNetStateInfo();
                    Filter(connInfos);
                    BindData(connInfos);
                    Thread.Sleep(100);
                }
            });
        }

        void Filter(List<ConnInfo> connInfos)
        {
            var version = comboBox1.Text;
            var filterWords = textBox1.Text;
            if (version == "IPv6")
                connInfos.RemoveAll(info => info.Address.Contains("."));
            else if (version == "IPv4")
                connInfos.RemoveAll(info => !info.Address.Contains("."));
            if (!string.IsNullOrWhiteSpace(filterWords))
            {
                var keyWords = filterWords.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries).Select(word => word.Trim());
                connInfos.RemoveAll(info =>
                    !keyWords.Any(word => info.Address.Contains(word) 
                                    || info.Address2.Contains(word)
                                    || info.Pid.ToString().Contains(word)
                                    || info.Pname.Contains(word)
                                    || info.Protocol.Contains(word)
                                    || info.Status.Contains(word))
                );
            }
        }

        void BindData(List<ConnInfo> connInfos)
        {
            if (dataGridView1.InvokeRequired)
                dataGridView1.Invoke(new Action<List<ConnInfo>>(BindData), connInfos);
            else
            {
                bool isEquals = true;
                var ds = dataGridView1.DataSource as List<ConnInfo>;
                if (ds.Count == connInfos.Count)
                {
                    for (int i = 0; i < ds.Count; i++)
                        if (ds[i] != connInfos[i])
                        {
                            isEquals = false;
                            break;
                        }
                }
                else
                    isEquals = false;
                if (!isEquals)
                    dataGridView1.DataSource = connInfos;
            }
        }

        Process pro;
        List<ConnInfo> GetNetStateInfo()
        {
            if (pro == null)
            {
                pro = new Process();
                pro.StartInfo.FileName = "cmd.exe";
                pro.StartInfo.UseShellExecute = false;
                pro.StartInfo.RedirectStandardInput = true;
                pro.StartInfo.RedirectStandardOutput = true;
                pro.StartInfo.RedirectStandardError = true;
                pro.StartInfo.CreateNoWindow = true;
            }
            pro.Start();
            pro.StandardInput.WriteLine("CLS");
            pro.StandardInput.WriteLine("netstat -ano");
            pro.StandardInput.WriteLine("exit");

            var infos = new List<ConnInfo>();
            string line;
            while ((line = pro.StandardOutput.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;
                var words = Regex.Split(line.Trim(), @"\s+");
                if (words.Length < 3 || (words[0] != "TCP" && words[0] != "UDP"))
                    continue;

                try
                {
                    var pid = int.Parse(words[words.Length - 1]);
                    var connInfo = new ConnInfo
                    {
                        Protocol = words[0],
                        Address = words[1],
                        Address2 = words[2],
                        Pid = pid,
                        Pname = Process.GetProcessById(pid)?.ProcessName
                    };
                    infos.Add(connInfo);
                }
                catch { }
            }
            pro.Close();
            infos.Sort(new Comparison<ConnInfo>((obj1, obj2) => string.Compare(obj1.Address, obj2.Address)));
            return infos;
        }
    }
}
