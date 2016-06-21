using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneWeb.Models
{
    public class Employee
    {
        public string Surname { get; set; } // фамилия
        public string Name { get; set; }
        public string Patronymic { get; set; } // отчество
        public string Phone { get; set; }
        public int Room { get; set; }
        public string Bureau { get; set; }
        public string Division { get; set; }
    }

    public class Employees : List<Employee>
    {
        public Employees()
        {
            /*
            this.AddEmployee("Name1", "Surname1", "Patronymic1", "5455", 416, "Админ. ОГТ", "ОГТ")
                .AddEmployee("Name2", "Surname2", "Patronymic1", "5455", 416, "БАКП", "ОГТ")
                .AddEmployee("Name3", "Surname3", "Patronymic1", "5455", 416, "БИО", "ОГТ")
                .AddEmployee("Name4", "Surname4", "Patronymic1", "5455", 416, "БКИ", "ОГТ")
                .AddEmployee("Name5", "Surname5", "Patronymic1", "5455", 416, "БКП", "ОГТ")
                .AddEmployee("Name6", "Surname6", "Patronymic1", "5455", 416, "БМиТТ", "ОГТ")
                .AddEmployee("Name7", "Surname7", "Patronymic1", "5455", 416, "БМТ", "ОГТ")
                .AddEmployee("Name8", "Surname8", "Patronymic1", "5455", 416, "БПД", "ОГТ")
                .AddEmployee("Name9", "Surname9", "Patronymic1", "5455", 416, "БРУП", "ОГТ")
                .AddEmployee("Name10", "Surname10", "Patronymic1", "5455", 416, "БТО", "ОГТ")
                .AddEmployee("Name11", "Surname11", "Patronymic1", "5455", 416, "ЛВПТ", "ОГТ")

                .AddEmployee("Name12", "Surname12", "Patronymic1", "5455", 416, "Админ. ПО", "ТО ППО")
                .AddEmployee("Name13", "Surname13", "Patronymic1", "5455", 416, "БПО №1", "ТО ППО")
                .AddEmployee("Name14", "Surname14", "Patronymic1", "5455", 416, "БПО №2", "ТО ППО")
                .AddEmployee("Name15", "Surname15", "Patronymic1", "5455", 416, "БРиЗ", "ТО ППО")
                .AddEmployee("Name16", "Surname16", "Patronymic1", "5455", 416, "БС ПО", "ТО ППО")
                .AddEmployee("Name17", "Surname17", "Patronymic1", "5455", 416, "БТиОН ПО", "ТО ППО")

                .AddEmployee("Name18", "Surname18", "Patronymic1", "5455", 416, "Админ. ГРО", "ТО ГР И КПО")
                .AddEmployee("Name19", "Surname19", "Patronymic1", "5455", 416, "БГШиПТО", "ТО ГР И КПО")
                .AddEmployee("Name20", "Surname20", "Patronymic1", "5455", 416, "БМГК", "ТО ГР И КПО")
                .AddEmployee("Name21", "Surname21", "Patronymic1", "5455", 416, "БНИиМ", "ТО ГР И КПО")
                .AddEmployee("Name22", "Surname22", "Patronymic1", "5455", 416, "БС ГРиКПО", "ТО ГР И КПО")

                .AddEmployee("Name23", "Surname23", "Patronymic1", "5455", 416, "БВиЭО", "ТО ПВ И ЭО")

                .AddEmployee("Name24", "Surname24", "Patronymic1", "5455", 416, "Админ. ПМиШПО", "ТО ПМ И ШПО")
                .AddEmployee("Name25", "Surname25", "Patronymic1", "5455", 416, "БМиШПО", "ТО ПМ И ШПО")
                .AddEmployee("Name26", "Surname26", "Patronymic1", "5455", 416, "БС ПМиШПО", "ТО ПМ И ШПО");
            */
        }

    }

    public static class EmployeeExtension
    {
        public static Employees AddEmployee(this Employees emloyees, string name, string surname,
            string patronymic, string phone, int room, string bureau, string division)
        {
            emloyees.Add(new Employee
            {
                Name = name,
                Surname = surname,
                Patronymic = patronymic,
                Phone = phone,
                Room = room,
                Bureau = bureau,
                Division = division
            });
            return emloyees;
        }
    }
}