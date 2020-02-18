using System;
using System.Windows.Controls;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Page1.xaml 的交互逻辑
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
            lbl.Content = "打开页面时间: " + DateTime.Now;
        }
    }
}
