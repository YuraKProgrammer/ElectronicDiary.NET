using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicDiary.Models
{
    public static class ToStringer
    {
        public static String TimePointToString(TimePoint timePoint)
        {
            var h = IntToNullPlusInt(timePoint.Hour);
            var m = IntToNullPlusInt(timePoint.Minute);
            return h + ":" + m;
        }

        public static String DurationToString(Duration duration)
        {
            return (duration.Hours * 60 + duration.Minutes).ToString();
        }
        public static String DurationToString2(TimePoint timePoint1, TimePoint timePoint2)
        {
            Duration d = new Duration(timePoint2.Hour - timePoint1.Hour, timePoint2.Minute - timePoint1.Minute);
            return DurationToString(d);
        }

        public static String IntToNullPlusInt(int a)
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

        public static String LessonTypeToString(LessonType lessonType)
        {
            switch (lessonType)
            {
                case Models.LessonType.Basic:
                    return " Обычный";
                case Models.LessonType.Additional:
                    return " Дополнительный";
                case Models.LessonType.Paid:
                    return " Платный";
            }
            return "";
        }

        public static String GradeToString(Grade grade)
        {
            switch (grade)
            {
                case Models.Grade.Five:
                    return "5";
                case Models.Grade.Four:
                    return "4";
                case Models.Grade.Three:
                    return "3";
                case Models.Grade.Two:
                    return "2";
                case Models.Grade.Missing:
                    return "Н";
            }
            return "";
        }

        public static String GradesToString(List<Grade> grades)
        {
            var s = "";
            foreach(Grade grade in grades)
            {
                s = s + GradeToString(grade)+" ";
            }
            return s;
        }
    }
}
