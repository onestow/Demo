using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp1.Model
{
    public class Menu2 : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Page _Page;
        public Page Page
        {
            get => _Page;
            set
            {
                _Page = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Page)));
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
