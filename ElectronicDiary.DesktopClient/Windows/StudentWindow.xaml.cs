using ElectronicDiary.SchoolDayStorage;
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
using System.Windows.Shapes;

namespace ElectronicDiary.DesktopClient.Windows
{
    /// <summary>
    /// Interaction logic for StudentWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        public ISchoolDayStorage schoolDayStorage = new TempSchoolDayStorage();
        public StudentWindow()
        {
            InitializeComponent();
            lb.ItemsSource = schoolDayStorage.Load(DateTime.Now).Schedule;
        }

        public void _lb_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
        }
    }
}
