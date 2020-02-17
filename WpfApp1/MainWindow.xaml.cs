using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using WpfApp1.CustomAnimation;
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
            SetNaviWidthByCount();
            DependencyPropertyDescriptor.FromProperty(ListBox.ItemsSourceProperty, typeof(ListBox)).AddValueChanged(lbNavi, (o, e)=>
            {
                SetNaviWidthByCount();
            });
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

        private void GridSplitter_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SetNaviWidthWithAnimation(cdNavi.Width.Value == 0 ? 150 : 0);
        }

        private void SetNaviWidthWithAnimation(double width)
        {
            if (cdNavi.Width.GridUnitType != GridUnitType.Pixel)
                throw new Exception("仅支持 ColumnDefinition.Width.GridUnitType == GridUnitType.Pixel");

            var animation = new GridLengthWidthAnimation
            {
                From = cdNavi.Width.Value,
                To = width,
                Duration = new Duration(TimeSpan.FromMilliseconds(200))
            };
            Storyboard.SetTarget(animation, cdNavi);
            Storyboard.SetTargetProperty(animation, new PropertyPath("(ColumnDefinition.Width)"));
            var sb = new Storyboard();
            sb.Children.Add(animation);
            sb.FillBehavior = FillBehavior.Stop;
            sb.Completed += (sender1, e1) =>
            {
                cdNavi.Width = new GridLength(width);
            };
            sb.Begin();
        }

        private void SetNaviWidthByCount()
        {
            if ((lbNavi.ItemsSource as ObservableCollection<Menu2>)?.Count > 1)
            {
                if (cdNavi.Width.Value == 0)
                    SetNaviWidthWithAnimation(150);
            }
            else
                SetNaviWidthWithAnimation(0);
        }
    }
}
