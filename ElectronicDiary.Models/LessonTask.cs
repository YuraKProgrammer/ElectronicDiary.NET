using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicDiary.Models
{
    public class LessonTask
    {
        public String Title { get; set; }
        public String Homework { get; set; }
        public LessonTask(string title, string homework)
        {
            Title = title;
            Homework = homework;
        }
    }
}
