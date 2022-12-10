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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ElectronicDiary.DesktopClient.Controls
{
    /// <summary>
    /// Interaction logic for LessonControl.xaml
    /// </summary>
    public partial class LessonControl : UserControl
    {
        private Lesson _lesson;
        public Lesson Lesson
        {
            get
            {
                return _lesson;
            }
            set
            {
                _lesson = value;
                Title.Text = _lesson.Title+" ";
                Homework.Text = " "+_lesson.Homework+" ";
                if (_lesson.Grades != null && _lesson.Grades.Count>0)
                {
                    Grade.Text = ToStringer.GradesToString(_lesson.Grades);
                }
                StartTime.Text = ToStringer.TimePointToString(_lesson.StartTime);
                EndTime.Text = ToStringer.TimePointToString(_lesson.EndTime);
                LessonType.Text = ToStringer.LessonTypeToString(_lesson.lessonType);
            }
        }
        private void LessonControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Lesson = DataContext as Lesson;
        }

        public LessonControl(Lesson lesson) : this()
        {
            InitializeComponent();
            _lesson = lesson;
            Title.Text = lesson.Title + " ";
            Homework.Text = " "+lesson.Homework + " ";
            if (lesson.Grades != null && _lesson.Grades.Count > 0)
            {
                Grade.Text = ToStringer.GradesToString(lesson.Grades);
            }
            StartTime.Text = ToStringer.TimePointToString(lesson.StartTime) + " ";
            EndTime.Text = ToStringer.TimePointToString(lesson.EndTime) + " ";
            LessonType.Text = " " + ToStringer.LessonTypeToString(lesson.lessonType) + " ";
        }
     
        public LessonControl()
        {
            InitializeComponent();
            DataContextChanged += LessonControl_DataContextChanged;
        }
    }
}
