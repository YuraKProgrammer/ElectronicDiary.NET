using ElectronicDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicDiary.SchoolDayStorage
{
    public class TempSchoolDayStorage : ISchoolDayStorage
    {
        public SchoolDay Load(DateTime dateTime)
        {
            return new SchoolDay(new List<Lesson>()
            {
                new Lesson("Математика",LessonType.Basic,"Сложение","Не задано",new TimePoint(8,30),new TimePoint(9,10)),
                new Lesson("Русский",LessonType.Basic,"Написание букв","Не задано",new TimePoint(9,30),new TimePoint(10,10))
            }
            ,new Date(10,10,2020));
        }

        public void Save(SchoolDay schoolDay)
        {
        }
    }
}
