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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1.Pages
{
    /// <summary>
    /// CalendarPage.xaml 的交互逻辑
    /// </summary>
    public partial class CalendarPage : Page
    {
        public CalendarPage()
        {
            InitializeComponent();
        }
    }

    public class CalendarViewModel : INotifyPropertyChanged
    {
        private const int displayDateCount = 7;
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<TestModel> ListData { get; set; }

        private List<DateTime> _ListDate;
        public List<DateTime> ListDate
        {
            get => _ListDate;
            set
            {
                _ListDate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ListDate)));
            }
        }

        public ICommand NextDatesCommand => new RelayCommand<object>(o =>
        {
            ListDate = GetSomeDay(ListDate[0].AddDays(displayDateCount));
        });

        public ICommand PrevDatesCommand => new RelayCommand<object>(o =>
        {
            ListDate = GetSomeDay(ListDate[0].AddDays(-displayDateCount));
        });


        public CalendarViewModel()
        {
            ListData = new ObservableCollection<TestModel>
            {
                new TestModel
                {
                    Title = "停牌日",
                    ListProd = new List<string>{ "三维通信", "中银盛利" }
                },
                new TestModel
                {
                    Title = "复牌日",
                    ListProd = new List<string>{ "中国动力" }
                },
                new TestModel
                {
                    Title = "中签率公告日",
                    ListProd = new List<string>{ "科安达", "神驰机电", "龙软科技" }
                }
            };

            var now = DateTime.Now.Date;
            ListDate = GetSomeDay(now.AddDays(-(int)now.DayOfWeek));
        }

        private List<DateTime> GetSomeDay(DateTime firstDate)
        {
            List<DateTime> listDate = new List<DateTime>();
            for (int i = 0; i < displayDateCount; i++)
                listDate.Add(firstDate.AddDays(i));

            return listDate;
        }
    }

    public class TestModel
    {
        public string Title { get; set; }
        public List<string> ListProd { get; set; }
    }
}
