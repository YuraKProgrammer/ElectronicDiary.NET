using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicDiary.Models
{
    [Serializable]
    public class SchoolDay
    {
        public List<Lesson> Schedule { get; set; }
        public ElectronicDiary.Models.Date Date { get; set; }
        public SchoolDay(List<Lesson> schedule, ElectronicDiary.Models.Date date)
        {
            Schedule = schedule;
            Date = date;
        }

        public void AddToShedule(Lesson isOnSchedule)
        {
            Schedule.Add(isOnSchedule);
        }
        public void RemoveFromShedule(Lesson isOnSchedule)
        {
            Schedule.Remove(isOnSchedule);
        }
    }
}
