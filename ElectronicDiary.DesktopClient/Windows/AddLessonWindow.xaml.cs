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
    /// Interaction logic for AddLessonWindow.xaml
    /// </summary>
    public partial class AddLessonWindow : Window
    {
        public ISchoolDayStorage storage = new TempSchoolDayStorage();
        public DateTime DateTime { get; set; }
        public AddLessonWindow(DateTime dateTime)
        {
            InitializeComponent();
            DateTime = dateTime;
        }

        public void _Add(object sender, RoutedEventArgs e)
        {
            List<SchoolDay> schoolDays = storage.LoadAll();
            foreach(var sd in schoolDays)
            {
                if (Comparer.CompareDateAndDateTime(sd.Date,DateTime))
                {
                    var day = schoolDays.Where(sd => Comparer.CompareDateAndDateTime(sd.Date,DateTime)).FirstOrDefault();
                    
                }
            }
        }
    }
}
