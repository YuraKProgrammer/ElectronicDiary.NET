using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicDiary.Models
{
    public class TimePoint
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
        public TimePoint(int hour, int minute)
        {
            Hour = hour;
            Minute = minute;
        }
    }
}
