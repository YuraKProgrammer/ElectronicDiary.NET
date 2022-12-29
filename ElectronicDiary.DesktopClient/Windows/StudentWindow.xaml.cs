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
    /// Interaction logic for StudentWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        public ISchoolDayStorage schoolDayStorage = new TempSchoolDayStorage();
        public DateTime currentDate = DateTime.Now;

        public StudentWindow(Account account)
        {
            InitializeComponent();
            Name.Text = account.Surname + " " + account.Name + " " + account.Patronymic;
            if (schoolDayStorage.Load(currentDate) != null)
            {
                lb.ItemsSource = schoolDayStorage.Load(currentDate).Schedule;
            }
            if (schoolDayStorage.Load(currentDate) != null)
            {
                var l = new List<LessonTask>();
                foreach (var les in schoolDayStorage.Load(currentDate).Schedule)
                {
                    l.Add(new LessonTask(les.Title, les.Homework));
                }
                lb2.ItemsSource = l;
            }
            _dateTime.Text = currentDate.Day.ToString() + "." + currentDate.Month.ToString() + "." + currentDate.Year.ToString();
        }

        public void _lb_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            var window = new ViewLessonWindow((Lesson)lb.SelectedItem);
            window.Show();
        }

        public void _shedule_reload(object sender, RoutedEventArgs e)
        {
            if (schoolDayStorage.Load(currentDate) != null)
            {
                lb.ItemsSource = schoolDayStorage.Load(currentDate).Schedule;
            }
            else
            {
                MessageBox.Show("Расписания на сегодня нет", "Сообщение");   
            }
        }

        public void _homework_reload(object sender, RoutedEventArgs e)
        {
            if (schoolDayStorage.Load(currentDate) != null)
            {
                var l = new List<LessonTask>();
                foreach(var les in schoolDayStorage.Load(currentDate).Schedule)
                {
                    l.Add(new LessonTask(les.Title,les.Homework));
                }
                lb2.ItemsSource = l;
            }
            else
            {
                MessageBox.Show("Домашних заданий на сегодня нет", "Сообщение");
            }
        }

        public void _grades_reload(object sender, RoutedEventArgs e)
        {
            if (schoolDayStorage.Load(currentDate) != null)
            {
                var l = new List<LessonGrade>();
                foreach (var les in schoolDayStorage.Load(currentDate).Schedule)
                {
                    l.Add(new LessonGrade(les.Title, les.Grades));
                }
                lb3.ItemsSource = l;
            }
            else
            {
                MessageBox.Show("Оценок за сегодня нет", "Сообщение");
            }
        }

        private void reloadAll()
        {
            if (schoolDayStorage.Load(currentDate) != null)
            {
                lb.ItemsSource = schoolDayStorage.Load(currentDate).Schedule;
            }
            else
            {
                lb.ItemsSource = new List<Lesson>();
            }
            if (schoolDayStorage.Load(currentDate) != null)
            {
                var l = new List<LessonTask>();
                foreach (var les in schoolDayStorage.Load(currentDate).Schedule)
                {
                    l.Add(new LessonTask(les.Title, les.Homework));
                }
                lb2.ItemsSource = new List<LessonTask>();
            }
            else
            {
                lb2.ItemsSource = new List<Lesson>();
            }
            if (schoolDayStorage.Load(currentDate) != null)
            {
                var l = new List<LessonGrade>();
                foreach (var les in schoolDayStorage.Load(currentDate).Schedule)
                {
                    l.Add(new LessonGrade(les.Title, les.Grades));
                }
                lb3.ItemsSource = l;
            }
            else
            {
                lb3.ItemsSource = new List<LessonGrade>();
            }
            _dateTime.Text = currentDate.Day.ToString() + "." + currentDate.Month.ToString() + "." + currentDate.Year.ToString();
        }

        public void _nextDay(object sender, RoutedEventArgs e)
        {
            currentDate = currentDate.AddDays(1);
            reloadAll();
        }

        public void _previousDay(object sender, RoutedEventArgs e)
        {
            currentDate = currentDate.AddDays(-1);
            reloadAll();
        }

        public void _next3Day(object sender, RoutedEventArgs e)
        {
            currentDate = currentDate.AddDays(3);
            reloadAll();
        }

        public void _previous3Day(object sender, RoutedEventArgs e)
        {
            currentDate = currentDate.AddDays(-3);
            reloadAll();
        }

        public void _nextWeek(object sender, RoutedEventArgs e)
        {
            currentDate = currentDate.AddDays(7);
            reloadAll();
        }

        public void _previousWeek(object sender, RoutedEventArgs e)
        {
            currentDate = currentDate.AddDays(-7);
            reloadAll();
        }
    }
}
