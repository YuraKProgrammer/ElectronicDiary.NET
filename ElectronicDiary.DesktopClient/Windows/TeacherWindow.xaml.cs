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
    /// Interaction logic for TeacherWindow.xaml
    /// </summary>
    public partial class TeacherWindow : Window
    {
        public ISchoolDayStorage schoolDayStorage = new TempSchoolDayStorage();
        public DateTime currentDate = DateTime.Now;
        public TeacherWindow(Account account)
        {
            InitializeComponent();
            Name.Text = account.Surname + " " + account.Name + " " + account.Patronymic;
            if (schoolDayStorage.Load(currentDate) != null)
            {
                lb.ItemsSource = schoolDayStorage.Load(DateTime.Now).Schedule;
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
            var window = new EditLessonWindow(currentDate, (Lesson)lb.SelectedItem);
            window.Show();
            update();
        }

        private void update()
        {
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
            if (schoolDayStorage.Load(currentDate) != null)
            {
                var l = new List<LessonGrade>();
                foreach (var les in schoolDayStorage.Load(currentDate).Schedule)
                {
                    l.Add(new LessonGrade(les.Title, les.Grades));
                }
                lb3.ItemsSource = l;
            }
        }

        public void _schedule_reload(object sender, RoutedEventArgs e)
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
                foreach (var les in schoolDayStorage.Load(currentDate).Schedule)
                {
                    l.Add(new LessonTask(les.Title, les.Homework));
                }
                lb2.ItemsSource = l;
            }
            else
            {
                MessageBox.Show("Домашние задания на сегодня не добавлены", "Сообщение");
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

        public void _addLesson(object sender, RoutedEventArgs e)
        {
            Window window = new AddLessonWindow(currentDate);
            window.Show();
            update();
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

        public void _addToSchedule(object sender, RoutedEventArgs e)
        {
            var lessons = schoolDayStorage.Load(currentDate).Schedule;
            var load = schoolDayStorage.Load(currentDate.AddDays(7));
            if (load == null || load.Schedule == null)
            {
                schoolDayStorage.Save(new SchoolDay(lessons, ToDater.DateTimeToDate(currentDate.AddDays(7))));
                MessageBox.Show("День успешно дабавлен в расписание через неделю", "Сообщение");
            }
            else
            {
                MessageBox.Show("Неудача. Расписание на день через неделю уже существует!", "Сообщение");
            }
        }

        public void _addToSchedule2(object sender, RoutedEventArgs e)
        {
            var lessons = schoolDayStorage.Load(currentDate).Schedule;
            var load = schoolDayStorage.Load(currentDate.AddDays(14));
            if (load == null || load.Schedule == null)
            {
                schoolDayStorage.Save(new SchoolDay(lessons, ToDater.DateTimeToDate(currentDate.AddDays(14))));
                MessageBox.Show("День успешно дабавлен в расписание через две недели", "Сообщение");
            }
            else
            {
                MessageBox.Show("Неудача. Расписание на день через две недели уже существует!", "Сообщение");
            }
        }

        public void _addToScheduleMonth(object sender, RoutedEventArgs e)
        {
            var lessons = schoolDayStorage.Load(currentDate).Schedule;
            var load1 = schoolDayStorage.Load(currentDate.AddDays(7));
            var load2 = schoolDayStorage.Load(currentDate.AddDays(14));
            var load3 = schoolDayStorage.Load(currentDate.AddDays(21));
            var load4 = schoolDayStorage.Load(currentDate.AddDays(28));
            if ((load1 == null || load1.Schedule == null) && (load2 == null || load2.Schedule == null) && (load3 == null || load3.Schedule == null) && (load4 == null || load4.Schedule == null))
            {
                schoolDayStorage.Save(new SchoolDay(lessons, ToDater.DateTimeToDate(currentDate.AddDays(7))));
                schoolDayStorage.Save(new SchoolDay(lessons, ToDater.DateTimeToDate(currentDate.AddDays(14))));
                schoolDayStorage.Save(new SchoolDay(lessons, ToDater.DateTimeToDate(currentDate.AddDays(21))));
                schoolDayStorage.Save(new SchoolDay(lessons, ToDater.DateTimeToDate(currentDate.AddDays(28))));
                MessageBox.Show("День успешно дабавлен в расписание на каждую неделю в течение месяца", "Сообщение");
            }
            else
            {
                MessageBox.Show("Неудача. В какой-то из дней расписание уже существует!", "Сообщение");
            }
        }
    }
}
