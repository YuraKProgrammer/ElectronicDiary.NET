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
        public ISchoolDayStorage storage = new TempSchoolDayStorage();
        public EditLessonWindow(Lesson lesson)
        {
            InitializeComponent();
            Lesson = lesson;
            InitializeComponent();
            Title.Text = lesson.Title;
            Topic.Text = lesson.Topic;
            Homework.Text = lesson.Homework;
            StartTime.Text = ToStringer.TimePointToString(lesson.StartTime);
            EndTime.Text = ToStringer.TimePointToString(lesson.EndTime);
            if (lesson.Grades != null && lesson.Grades.Count > 0)
            {
                Grades.Text = lesson.Grades[0].ToString();
            }
            LessonType.Text = ToStringer.LessonTypeToString(lesson.lessonType);
            Duration.Text = ToStringer.DurationToString2(lesson.StartTime, lesson.EndTime) + " мин.";
        }

        private void _Save(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }

        private void _Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void _Delete(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
