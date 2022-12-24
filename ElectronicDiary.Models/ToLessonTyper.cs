using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicDiary.Models
{
    public static class ToLessonTyper
    {
        public static LessonType StringToLessonType(string String)
        {
            switch (String)
            {
                case "Обычный": return LessonType.Basic; break;
                case " Обычный": return LessonType.Basic; break;
                case "Дополнительный": return LessonType.Additional; break;
                case " Дополнительный": return LessonType.Additional; break;
                case "Платный": return LessonType.Paid; break;
                case " Платный": return LessonType.Paid; break;
                default: return LessonType.Basic;
            }
        }
    }
}
