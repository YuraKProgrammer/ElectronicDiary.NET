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
        public TeacherWindow(Account account)
        {
            InitializeComponent();
            Name.Text = account.Surname + " " + account.Name + " " + account.Patronymic;
            if (schoolDayStorage.Load(DateTime.Now) != null)
            {
                lb.ItemsSource = schoolDayStorage.Load(DateTime.Now).Schedule;
            }
            if (schoolDayStorage.Load(DateTime.Now) != null)
            {
                var l = new List<LessonTask>();
                foreach (var les in schoolDayStorage.Load(DateTime.Now).Schedule)
                {
                    l.Add(new LessonTask(les.Title, les.Homework));
                }
                lb2.ItemsSource = l;
            }
        }

        public void _lb_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            var window = new ViewLessonWindow((Lesson)lb.SelectedItem);
            window.Show();
        }

        public void _shedule_reload(object sender, RoutedEventArgs e)
        {
            if (schoolDayStorage.Load(DateTime.Now) != null)
            {
                lb.ItemsSource = schoolDayStorage.Load(DateTime.Now).Schedule;
            }
            else
            {
                MessageBox.Show("Расписания на сегодня нет", "Сообщение");
            }
        }

        public void _homework_reload(object sender, RoutedEventArgs e)
        {
            if (schoolDayStorage.Load(DateTime.Now) != null)
            {
                var l = new List<LessonTask>();
                foreach (var les in schoolDayStorage.Load(DateTime.Now).Schedule)
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
            if (schoolDayStorage.Load(DateTime.Now) != null)
            {
                var l = new List<LessonGrade>();
                foreach (var les in schoolDayStorage.Load(DateTime.Now).Schedule)
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
            Window window = new AddLessonWindow(DateTime.UtcNow);
            window.Show();
        }
        public void _addSchedule(object sender, RoutedEventArgs e)
        {
        }
    }
}
