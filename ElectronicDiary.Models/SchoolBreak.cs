using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicDiary.Models
{
    public class SchoolBreak : IsOnSchedule
    {
        public TimePoint StartTime { get; set; }
        public TimePoint EndTime { get; set; }
        public SchoolBreak(TimePoint startTime, TimePoint endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }

        public void SetTime1(TimePoint startTime, TimePoint endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }
        public void SetTime2(TimePoint startTime, Duration duration)
        {
            StartTime = startTime;
            EndTime.Hour = startTime.Hour + duration.Hours;
            EndTime.Minute = startTime.Minute + duration.Minutes;
        }
    }
}
