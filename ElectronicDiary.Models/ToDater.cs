using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicDiary.Models
{
    public static class ToDater
    {
        public static Date DateTimeToDate(DateTime dateTime)
        {
            return new Date(dateTime.Day, dateTime.Month, dateTime.Year);
        }
    }
}
