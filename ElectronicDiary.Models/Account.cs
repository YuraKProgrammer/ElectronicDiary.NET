using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicDiary.Models
{
    public class Account
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public AccountType AccountType { get; }
        public Account(string name, string surname, string patronymic, AccountType accountType)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            AccountType = accountType;
        }
    }
}
