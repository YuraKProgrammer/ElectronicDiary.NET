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
    /// Interaction logic for AddLessonWindow.xaml
    /// </summary>
    public partial class AddLessonWindow : Window
    {
        public ISchoolDayStorage storage = new TempSchoolDayStorage();
        public DateTime DateTime { get; set; }
        public AddLessonWindow(DateTime dateTime)
        {
            InitializeComponent();
            DateTime = dateTime;
        }

        public void _Add(object sender, RoutedEventArgs e)
        {
            List<SchoolDay> schoolDays = storage.LoadAll();
            foreach (var sd in schoolDays)
            {
                if (Comparer.CompareDateAndDateTime(sd.Date, DateTime))
                {
                    var day1 = schoolDays.Where(sd => Comparer.CompareDateAndDateTime(sd.Date, DateTime)).FirstOrDefault();
                    storage.RemoveDay(day1);
                    Lesson les1 = new Lesson(
                        _Title.Text,
                        new TimePoint(Int32.Parse(_StartHour.Text), Int32.Parse(_StartMinute.Text)),
                        new TimePoint(Int32.Parse(_EndHour.Text), Int32.Parse(_EndMinute.Text)));
                    day1.AddToShedule(les1);
                    storage.Save(day1);
                }
            }
            var day = new SchoolDay(new List<Lesson>(), new Date(DateTime.Day,DateTime.Month, DateTime.Year));
            Lesson les = new Lesson(
                        _Title.Text,
                        new TimePoint(Int32.Parse(_StartHour.Text), Int32.Parse(_StartMinute.Text)),
                        new TimePoint(Int32.Parse(_EndHour.Text), Int32.Parse(_EndMinute.Text)));
            day.AddToShedule(les);
            storage.Save(day);
            this.Close();
        }

        public void _Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
