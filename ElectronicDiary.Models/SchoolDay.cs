using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicDiary.Models
{
    public class SchoolDay
    {
        public List<IsOnSchedule> Schedule { get; set; }
        public ElectronicDiary.Models.Date Date { get; set; }
        public SchoolDay(ElectronicDiary.Models.Date date)
        {
            Date = date;
            Schedule = new List<IsOnSchedule>();
        }
        public SchoolDay(List<IsOnSchedule> schedule, ElectronicDiary.Models.Date date)
        {
            Schedule = schedule;
            Date = date;
        }

        public void AddToShedule(IsOnSchedule isOnSchedule)
        {
            Schedule.Add(isOnSchedule);
        }
        public void RemoveFromShedule(IsOnSchedule isOnSchedule)
        {
            Schedule.Remove(isOnSchedule);
        }
    }
}
