using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Model;

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        double menu1ScrollableWidth;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void mainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            menu1ScrollableWidth = scrollViewer.ScrollableWidth;
        }

        private void Header_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
            if (e.ClickCount == 2)
            {
                this.WindowState = this.WindowState == WindowState.Normal ?
                    WindowState.Maximized : WindowState.Normal;
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Max_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
        }
        private void Min_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void LeftButton_Click(object sender, RoutedEventArgs e)
        {
            ScrollViewerOffset(Math.Max(this.Width - 180, 100));
        }

        private void RightButton_Click(object sender, RoutedEventArgs e)
        {
            ScrollViewerOffset(-Math.Max(this.Width - 180, 100));
        }

        private void ScrollViewerOffset(double offset)
        {
            var left = Math.Min(0, lbMenu.Margin.Left + offset);
            left = Math.Max(left, lbMenu.Margin.Left - scrollViewer.ScrollableWidth);
            lbMenu.BeginAnimation(MarginProperty, new ThicknessAnimation()
            {
                From = lbMenu.Margin,
                To = new Thickness(left, 0, 0, 0),
                Duration = new Duration(TimeSpan.FromMilliseconds(400)),
            });
        }

    }

    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region property
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Menu1> ListMenu { get; } = new ObservableCollection<Menu1>();

        private Menu1 _CurrMenu1;
        public Menu1 CurrMenu1
        {
            get => _CurrMenu1;
            set
            {
                _CurrMenu1 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrMenu1)));
            }
        }

        private Menu2 _CurrMenu2;
        public Menu2 CurrMenu2
        {
            get => _CurrMenu2;
            set
            {
                _CurrMenu2 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrMenu2)));
            }
        }
        #endregion

        #region command
        public ICommand Menu1Command => new RelayCommand<Menu1>((model) =>
        {
            if (model == CurrMenu1)
                return;

            CurrMenu1 = model;
            MessageBox.Show(model.Text);
        });
        #endregion

        public MainWindowViewModel()
        {
            if (true || DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                ListMenu.Add(new Menu1("/Images/maximize64.png", "文件工具"));
                ListMenu.Add(new Menu1("/Images/maximize64.png", "指令签名"));
                ListMenu.Add(new Menu1("/Images/maximize64.png", "文件披露MD5"));
                ListMenu.Add(new Menu1("/Images/maximize64.png", "文件披露MD6"));
                ListMenu.Add(new Menu1("/Images/maximize64.png", "文件披露MD7"));
                ListMenu.Add(new Menu1("/Images/maximize64.png", "文件披露MD8"));
                ListMenu.Add(new Menu1("/Images/maximize64.png", "文件披露MD9"));
                ListMenu.Add(new Menu1("/Images/maximize64.png", "文件披露MD10"));
                ListMenu.Add(new Menu1("/Images/maximize64.png", "文件披露MD11"));
                ListMenu.Add(new Menu1("/Images/maximize64.png", "文件披露MD12"));
                ListMenu.Add(new Menu1("/Images/maximize64.png", "文件披露MD13"));
                ListMenu.Add(new Menu1("/Images/maximize64.png", "文件披露MD14"));
                ListMenu.Add(new Menu1("/Images/maximize64.png", "文件披露MD15"));
                ListMenu.Add(new Menu1("/Images/maximize64.png", "文件披露MD16"));
                ListMenu.Add(new Menu1("/Images/maximize64.png", "文件披露MD17"));
                ListMenu.Add(new Menu1("/Images/maximize64.png", "文件披露MD18"));
                ListMenu.Add(new Menu1("/Images/maximize64.png", "文件披露MD19"));
                ListMenu.Add(new Menu1("/Images/maximize64.png", "文件披露MD20"));
                ListMenu.Add(new Menu1("/Images/maximize64.png", "文件披露MD21"));
                ListMenu.Add(new Menu1("/Images/maximize64.png", "文件披露MD22"));
                ListMenu.Add(new Menu1("/Images/maximize64.png", "文件披露MD23"));
                ListMenu.Add(new Menu1("/Images/maximize64.png", "文件披露MD24"));
                ListMenu.Add(new Menu1("/Images/maximize64.png", "文件披露MD25"));
                ListMenu.Add(new Menu1("/Images/maximize64.png", "文件披露MD26"));
            }
        }
    }
}
