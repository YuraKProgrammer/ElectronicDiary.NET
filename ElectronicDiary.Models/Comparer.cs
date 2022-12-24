using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicDiary.Models
{
    public static class Comparer
    {
        public static bool CompareDates(Date date1, Date date2)
        {
            if (date1 != null && date2 != null)
            {
                if (date1.Year==date2.Year && date1.Month == date2.Month && date1.Day == date2.Day)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public static bool CompareDateAndDateTime(Date date1, DateTime date2)
        {
            if (date1 != null && date2 != null)
            {
                if (date1.Year == date2.Year && date1.Month == date2.Month && date1.Day == date2.Day)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public static bool CompareTimePoints(TimePoint timePoint1, TimePoint timePoint2)
        {
            if (timePoint1 != null && timePoint2 != null)
            {
                if (timePoint1.Hour==timePoint2.Hour && timePoint1.Minute == timePoint2.Minute)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
