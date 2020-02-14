using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfApp1.Model
{
    public class Menu1 : INotifyPropertyChanged
    {
        public Menu1(string uri, string text)
        {
            Image = new BitmapImage(new Uri(uri, UriKind.RelativeOrAbsolute));
            Text = text;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private ImageSource _Image;
        public ImageSource Image
        {
            get => _Image;
            set
            {
                _Image = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Image)));
            }
        }

        private string _Text = "";
        public string Text
        {
            get => _Text;
            set
            {
                _Text = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Text)));
            }
        }

        public ObservableCollection<Menu2> SubMenus { get; } = new ObservableCollection<Menu2>();
    }
}
