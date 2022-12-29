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
    /// Interaction logic for EditLessonWindow.xaml
    /// </summary>
    public partial class EditLessonWindow : Window
    {
        public Lesson Lesson;
        public DateTime DateTime;
        public ISchoolDayStorage storage = new TempSchoolDayStorage();
        public EditLessonWindow(DateTime dateTime,Lesson lesson)
        {
            Lesson = lesson;
            DateTime = dateTime;
            InitializeComponent();
            Title.Text = lesson.Title;
            Topic.Text = lesson.Topic;
            Homework.Text = lesson.Homework;
            StartTime.Text = ToStringer.TimePointToString(lesson.StartTime);
            EndTime.Text = ToStringer.TimePointToString(lesson.EndTime);
            if (lesson.Grades != null && lesson.Grades.Count > 0)
            {
                Grades.Text = ToStringer.GradesToString(lesson.Grades);
            }
            LessonType.Text = ToStringer.LessonTypeToString(lesson.lessonType);
            Duration.Text = ToStringer.DurationToString2(lesson.StartTime, lesson.EndTime) + " мин.";
        }

        private void _Save(object sender, RoutedEventArgs e)
        {
            List<SchoolDay> schoolDays = storage.LoadAll();
            var day1 = schoolDays.Where(sd => Comparer.CompareDateAndDateTime(sd.Date, DateTime)).FirstOrDefault();
            storage.RemoveDay(day1);
            var les1 = day1.Schedule.Where(l => Comparer.CompareTimePoints(l.StartTime, Lesson.StartTime) && Comparer.CompareTimePoints(l.EndTime, Lesson.EndTime)).FirstOrDefault();
            day1.RemoveFromShedule(les1);
            Lesson les2 = new Lesson(
                Title.Text,
                ToLessonTyper.StringToLessonType(LessonType.Text),
                Topic.Text,
                Homework.Text,
                Lesson.StartTime,
                Lesson.EndTime); 
            foreach(var g in ToGrader.StringToGrades(Grades.Text))
            {
                les2.AddGrade(g);
            }
            day1.AddToShedule(les2);
            storage.Save(day1);
            this.Close();
        }

        private void _Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void _Delete(object sender, RoutedEventArgs e)
        {
            List<SchoolDay> schoolDays = storage.LoadAll();
            var day1 = schoolDays.Where(sd => Comparer.CompareDateAndDateTime(sd.Date, DateTime)).FirstOrDefault();
            storage.RemoveDay(day1);
            var les1 = day1.Schedule.Where(l => Comparer.CompareTimePoints(l.StartTime, Lesson.StartTime) && Comparer.CompareTimePoints(l.EndTime, Lesson.EndTime)).FirstOrDefault();
            day1.RemoveFromShedule(les1);
            storage.Save(day1);
            this.Close();
        }
    }
}
