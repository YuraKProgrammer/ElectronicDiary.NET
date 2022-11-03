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
        public Lesson Lesson;
        private void LessonControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Lesson = DataContext as Lesson;
        }

        public LessonControl()
        {
            InitializeComponent();
            DataContextChanged += LessonControl_DataContextChanged;
            Title.Text = Lesson.Title;
            Homework.Text = Lesson.Homework;
            if (Lesson.Grades != null)
            {
                Grade.Text = Lesson.Grades.ToString();
            }
            StartTime.Text = TimePointToString(Lesson.StartTime);
            EndTime.Text = TimePointToString(Lesson.EndTime);
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
