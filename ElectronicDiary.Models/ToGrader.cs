using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicDiary.Models
{
    public static class ToGrader
    {
        public static List<Grade> StringToGrades(String str)
        {
            String[] strs = str.Split(' ');
            List<Grade> grades = new List<Grade>();
            foreach(String s in strs)
            {
                grades.Add(StringToGrade(s));
            }
            return grades;
        }

        public static Grade StringToGrade(String str)
        {
            switch (str)
            {
                case "5": return Grade.Five;
                case "4": return Grade.Four;
                case "3": return Grade.Three;
                case "2": return Grade.Two;
                case "Н": return Grade.Missing;
                default: return Grade.Missing; 
            }
        }
    }
}
