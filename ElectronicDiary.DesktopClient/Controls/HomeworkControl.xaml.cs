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
    /// Interaction logic for HomeworkControl.xaml
    /// </summary>
    public partial class HomeworkControl : UserControl
    {
        private LessonTask _lessonTask;
        public LessonTask LessonTask
        {
            get
            {
                return _lessonTask;
            }
            set
            {
                _lessonTask = value;
                TextHomework.Text = _lessonTask.Homework;
                TextTitle.Text = _lessonTask.Title;
            }
        }
        private void HomeworkControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            LessonTask = DataContext as LessonTask;    
        }

        public HomeworkControl(LessonTask lessonTask) : this()
        {
            InitializeComponent();
            _lessonTask = lessonTask;
        }

        public HomeworkControl()
        {
            InitializeComponent();
            DataContextChanged += HomeworkControl_DataContextChanged;
        }
    }
}
