using ElectronicDiary.DesktopClient.Controls;
using ElectronicDiary.Models;
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
    /// Interaction logic for ParentWindow.xaml
    /// </summary>
    public partial class ParentWindow : Window
    {
        public ISchoolDayStorage schoolDayStorage = new TempSchoolDayStorage();
        public ParentWindow(Account parentAccount, Account studentAccount)
        {
            InitializeComponent();
            Name.Text = parentAccount.Surname + " " + parentAccount.Name + " " + parentAccount.Patronymic;
            StudentName.Text = studentAccount.Surname + " " + studentAccount.Name + " " + studentAccount.Patronymic;
            var list = new List<LessonControl>();
            foreach (var les in schoolDayStorage.Load(DateTime.Now).Schedule)
            {
                list.Add(new LessonControl(les));
            }
            lb.ItemsSource = schoolDayStorage.Load(DateTime.Now).Schedule;
        }

        public void _lb_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            var window = new ViewLessonWindow((Lesson)lb.SelectedItem);
            window.Show();
        }
    }
}
