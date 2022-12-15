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
            {
                string[] stroki = File.ReadAllLines("D:\\ElectronicDiary.dat");
                if (stroki.Length > 0)
                {
                    using (FileStream fs = new FileStream("D:\\ElectronicDiary.dat", FileMode.OpenOrCreate))
                    {
                        schoolDays = (List<SchoolDay>)formatter.Deserialize(fs);
                    }
                }
                else
                {
                    schoolDays = new List<SchoolDay>();
                }
            }
            else
            {
                schoolDays = new List<SchoolDay>();
            }
        }

        public List<SchoolDay> LoadAll()
        {
            LoadAllSchoolDays();
            return schoolDays;
        }

        public void Save(SchoolDay schoolDay)
        {
            LoadAllSchoolDays();
            schoolDays.Add(schoolDay);
            using (FileStream fs = new FileStream("D:\\ElectronicDiary.dat", FileMode.OpenOrCreate))
            {
                fs.SetLength(0);
                formatter.Serialize(fs, schoolDays);
            }
        }

        public void RemoveDay(SchoolDay schoolDay)
        {
            LoadAllSchoolDays();
            schoolDays.Remove(schoolDays.Where(sd => Comparer.CompareDates(schoolDay.Date,sd.Date)).FirstOrDefault()); //Не работает
            using (FileStream fs = new FileStream("D:\\ElectronicDiary.dat", FileMode.OpenOrCreate))
            {
                fs.SetLength(0);
                formatter.Serialize(fs, schoolDays);
            }
        }
    }
}
