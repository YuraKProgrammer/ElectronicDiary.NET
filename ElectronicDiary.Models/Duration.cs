using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicDiary.Models
{
    [Serializable]
    public class Duration
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public Duration(int hours, int minutes)
        {
            Hours = hours;
            Minutes = minutes;
        }
    }
}
