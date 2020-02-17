using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp1.Model;
using WpfApp1.Pages;

namespace WpfApp1
{
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
                if (_CurrMenu1 == value)
                    return;
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
                if (_CurrMenu2 == value)
                    return;
                _CurrMenu2 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrMenu2)));
            }
        }

        private Page _CurrPage;
        public Page CurrPage
        {
            get => _CurrPage;
            set
            {
                if (_CurrPage == value)
                    return;
                _CurrPage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrPage)));
            }
        }
        #endregion

        #region command
        #endregion

        public MainWindowViewModel()
        {
            PropertyChanged += HandlePropertyChanged;
            #region 测试代码
            if (true || DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                ListMenu.Add(new Menu1("/Images/maximize64.png", "文件工具"));
                ListMenu.Add(new Menu1("/Images/maximize64.png", "指令签名"));
                ListMenu.Add(new Menu1("/Images/maximize64.png", "文件披露MA5"));
                ListMenu.Add(new Menu1("/Images/maximize64.png", "文件披露MB5"));
                ListMenu.Add(new Menu1("/Images/maximize64.png", "文件披露MC5"));
                ListMenu.Add(new Menu1("/Images/maximize64.png", "文件披露MD5"));
                ListMenu.Add(new Menu1("/Images/maximize64.png", "文件披露ME5"));
                ListMenu.Add(new Menu1("/Images/maximize64.png", "文件披露MF5"));
                ListMenu.Add(new Menu1("/Images/maximize64.png", "文件披露MG5"));
                ListMenu.Add(new Menu1("/Images/maximize64.png", "文件披露MH5"));
                ListMenu.Add(new Menu1("/Images/maximize64.png", "文件披露MI5"));
                ListMenu.Add(new Menu1("/Images/maximize64.png", "文件披露MJ5"));
                ListMenu.Add(new Menu1("/Images/maximize64.png", "文件披露MK5"));
                ListMenu.Add(new Menu1("/Images/maximize64.png", "文件披露ML5"));
                ListMenu.Add(new Menu1("/Images/maximize64.png", "文件披露MM5"));
                ListMenu.Add(new Menu1("/Images/maximize64.png", "文件披露MN5"));
                ListMenu.Add(new Menu1("/Images/maximize64.png", "文件披露MO5"));
                ListMenu.Add(new Menu1("/Images/maximize64.png", "文件披露MP5"));
                ListMenu.Add(new Menu1("/Images/maximize64.png", "文件披露MQ5"));
                ListMenu.Add(new Menu1("/Images/maximize64.png", "文件披露MR5"));
                ListMenu.Add(new Menu1("/Images/maximize64.png", "文件披露MS5"));
                ListMenu.Add(new Menu1("/Images/maximize64.png", "文件披露MT5"));
                ListMenu.Add(new Menu1("/Images/maximize64.png", "文件披露MU5"));
                ListMenu.Add(new Menu1("/Images/maximize64.png", "文件披露MV5"));
                ListMenu.Add(new Menu1("/Images/maximize64.png", "文件披露MW5"));
                ListMenu.Add(new Menu1("/Images/maximize64.png", "文件披露MX5"));
                ListMenu.Add(new Menu1("/Images/maximize64.png", "文件披露MY5"));
                ListMenu.Add(new Menu1("/Images/maximize64.png", "文件披露MZ5"));

                var random = new Random();
                foreach (var menu1 in ListMenu)
                {
                    var cnt = random.Next(3, 10);
                    if (menu1.Text == "指令签名")
                        cnt = 1;
                    for (int i = 0; i < cnt; i++)
                        menu1.SubMenus.Add(new Menu2(menu1.Text + "_" + i, typeof(Page1)));
                }
            }
            #endregion

            CurrMenu1 = ListMenu[0];
        }

        void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(CurrMenu1):
                    CurrMenu2 = CurrMenu1?.SubMenus[0];
                    break;
                case nameof(CurrMenu2):
                    if (CurrMenu2 == null)
                    {
                        CurrPage = null;
                        return;
                    }
                    if (CurrMenu2.Page == null)
                    {
                        var ct = CurrMenu2.PageType.GetConstructor(new Type[0]);
                        CurrMenu2.Page = ct.Invoke(new object[0]) as Page;
                    }
                    CurrPage = CurrMenu2.Page;
                    break;
            }
        }

    }
}
