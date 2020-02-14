using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1.UserControls
{
    /// <summary>
    /// ImageButton.xaml 的交互逻辑
    /// </summary>
    public partial class ImageButton : Button
    {
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text",
            typeof(string), typeof(ImageButton),
            new FrameworkPropertyMetadata("", new PropertyChangedCallback((o, e)=>
        {
            var thisCtl = o as ImageButton;
            var text = e.NewValue as string;
            thisCtl.tb.Text = text;
            if (string.IsNullOrEmpty(text))
                thisCtl.tb.Visibility = Visibility.Collapsed;
            else
                thisCtl.tb.Visibility = Visibility.Visible;
        })));

        public ImageSource Image
        {
            get { return (ImageSource)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }
        public static readonly DependencyProperty ImageProperty = DependencyProperty.Register("Image",
            typeof(ImageSource), typeof(ImageButton),
            new FrameworkPropertyMetadata(default(ImageSource), new PropertyChangedCallback((o, e) =>
        {
            (o as ImageButton).img.Source = e.NewValue as ImageSource;
        })));

        public ImageButton()
        {
            InitializeComponent();
            //img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/全屏 最大化.png"));
        }
    }
}
