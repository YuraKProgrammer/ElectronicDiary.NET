using ElectronicDiary.Models;
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
    /// Interaction logic for ViewLessonWindow.xaml
    /// </summary>
    public partial class ViewLessonWindow : Window
    {
        private Lesson Lesson;
        public ViewLessonWindow(Lesson lesson)
        {
            Lesson = lesson;
            InitializeComponent();
            Title.Text = lesson.Title;
            Topic.Text = lesson.Topic;
            Homework.Text = lesson.Homework;
            StartTime.Text = ToStringer.TimePointToString(lesson.StartTime);
            EndTime.Text = ToStringer.TimePointToString(lesson.EndTime);
            if (lesson.Grades != null && lesson.Grades.Count>0)
            {
                Grades.Text = lesson.Grades[0].ToString();
            }
            LessonType.Text = ToStringer.LessonTypeToString(lesson.lessonType);
            Duration.Text = ToStringer.DurationToString2(lesson.StartTime, lesson.EndTime)+" мин.";
        }
    }
}
