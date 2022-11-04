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
                    Grade.Text = _lesson.Grades[0].ToString();
                }
                StartTime.Text = TimePointToString(_lesson.StartTime);
                EndTime.Text = TimePointToString(_lesson.EndTime);
                switch (_lesson.lessonType)
                {
                    case Models.LessonType.Basic:
                        LessonType.Text = "Обычный";
                        break;
                    case Models.LessonType.Additional:
                        LessonType.Text = "Дополнительный";
                        break;
                    case Models.LessonType.Paid:
                        LessonType.Text = "Платный";
                        break;
                }
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
            if (lesson.Grades != null)
            {
                Grade.Text = lesson.Grades.ToString();
            }
            StartTime.Text = TimePointToString(lesson.StartTime);
            EndTime.Text = TimePointToString(lesson.EndTime);
            switch (lesson.lessonType)
            {
                case Models.LessonType.Basic:
                    LessonType.Text = "Обычный";
                    break;
                case Models.LessonType.Additional:
                    LessonType.Text = "Дополнительный";
                    break;
                case Models.LessonType.Paid:
                    LessonType.Text = "Платный";
                    break;
            }
        }
     
        public LessonControl()
        {
            InitializeComponent();
            DataContextChanged += LessonControl_DataContextChanged;
        }

        public String TimePointToString(TimePoint timePoint)
        {
            var h = IntToNullPlusInt(timePoint.Hour);
            var m = IntToNullPlusInt(timePoint.Minute);
            return h + ":" + m;
        }

        public String IntToNullPlusInt(int a)
        {
            if (a < 10)
            {
                return "0" + a.ToString();
            }
            else
            {
                return a.ToString();
            }
        }
    }
}
