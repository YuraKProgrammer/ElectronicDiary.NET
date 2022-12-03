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
    /// Interaction logic for GradeControl.xaml
    /// </summary>
    public partial class GradeControl : UserControl
    {
        private LessonGrade _lessonGrade;
        public LessonGrade LessonGrade
        {
            get
            {
                return _lessonGrade;
            }
            set
            {
                _lessonGrade = value;
                TextGrades.Text = ToStringer.GradesToString(_lessonGrade.Grades);
                TextTitle.Text = _lessonGrade.Title;
            }
        }
        private void HomeworkControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            LessonGrade = DataContext as LessonGrade;
        }

        public GradeControl(LessonGrade lessonGrade) : this()
        {
            InitializeComponent();
            _lessonGrade = lessonGrade;
        }

        public GradeControl()
        {
            InitializeComponent();
            DataContextChanged += HomeworkControl_DataContextChanged;
        }
    }
}
