using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicDiary.Models
{
    public class Day
    {
        public List<IsOnSchedule> Schedule { get; set; }
        public Day()
        {

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
