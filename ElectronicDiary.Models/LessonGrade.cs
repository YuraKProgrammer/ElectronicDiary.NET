using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicDiary.Models
{
    public class LessonGrade
    {
        public String Title { get; set; }
        public List<Grade> Grades { get; set; }
        public LessonGrade(string title, List<Grade> grades)
        {
            Title = title;
            Grades = grades;
        }
    }
}
