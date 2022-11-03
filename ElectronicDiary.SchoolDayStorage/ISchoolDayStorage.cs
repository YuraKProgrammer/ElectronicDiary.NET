using ElectronicDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicDiary.SchoolDayStorage
{
    public interface ISchoolDayStorage
    {
        public SchoolDay Load(DateTime dateTime);
        public void Save(SchoolDay schoolDay);
    }
}
