using ElectronicDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicDiary.SchoolDayStorage
{
    public class TempSchoolDayStorage : ISchoolDayStorage
    {
        private List<SchoolDay> schoolDays = new List<SchoolDay>();
        private BinaryFormatter formatter = new BinaryFormatter();  
        public SchoolDay Load(DateTime dateTime)
        {
            LoadAllSchoolDays();
            var sd = schoolDays
                .Where(sd => sd.Date.Year == dateTime.Year)
                .Where(sd => sd.Date.Month == dateTime.Month)
                .Where(sd => sd.Date.Day == dateTime.Day)
                .ToList()
                .FirstOrDefault();
            return sd;
        }

        private void LoadAllSchoolDays()
        {
            if (File.Exists("D:\\ElectronicDiary.dat"))
                using (FileStream fs = new FileStream("D:\\ElectronicDiary.dat", FileMode.OpenOrCreate))
                {
                    schoolDays = (List<SchoolDay>)formatter.Deserialize(fs);
                }
        }

        public void Save(SchoolDay schoolDay)
        {
            LoadAllSchoolDays();
            schoolDays.Add(schoolDay);
            using (FileStream fs = new FileStream("D:\\ElectronicDiary.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, schoolDays);
            }
        }
    }
}
