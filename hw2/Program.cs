using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2
{

    class Program
    {

        static void Main(string[] args)
        {
            ArrayList list = new ArrayList();

            Director director = new Director("Egor");
            Manager manager = new Manager("Sam");
            Programmer programmer = new Programmer("Me");

            AddPerson(director, "Lena", list);
            AddPerson(programmer, "Katya", list);
            AddPerson(manager, "Vika", list);

            Console.WriteLine("\nТекущий лист:");
            foreach (var item in list)
            {
                Console.WriteLine((string)item);
            }
            Console.WriteLine();

            RenamePerson(programmer, "Katya", "Olya", list);
            RenamePerson(programmer, "Katya", "Olya", list);
            RenamePerson(director, "Katya", "Olya", list);
            RenamePerson(manager, "Katya", "Olya", list);

            Console.WriteLine("\nТекущий лист:");
            foreach (var item in list)
            {
                Console.WriteLine((string)item);
            }
            Console.WriteLine();

            RemovePerson(programmer, "Vika", list);
            RemovePerson(director, "Olya", list);
            RemovePerson(manager, "Olya", list);

            Console.WriteLine("\nТекущий лист:");
            foreach (var item in list)
            {
                Console.WriteLine((string)item);
            }
            Console.WriteLine();
            Console.ReadKey();

        }

        public static void AddPerson<T>(T employeeName, string Name, ArrayList arrayList)
        {
            Type employeeType = employeeName.GetType();
            object[] employeeAttributes = employeeType.GetCustomAttributes(false);
            foreach (AccessLevelAttribute employeeAccessLevel in employeeAttributes)
            {
                if (employeeAccessLevel.accessLevel == "director" ||
                    employeeAccessLevel.accessLevel == "programmer" ||
                    employeeAccessLevel.accessLevel == "manager")
                {
                    arrayList.Add(Name);
                    Console.WriteLine($"Человек {Name} добавлен в лист пользователем типа {Convert.ToString(employeeName).Replace("Att.", "")}");
                    return;
                }
            }
            Console.WriteLine($"Доступ запрещен!\n");
        }

        [AccessLevel(accessLevel = "director")]
        public static void RemovePerson<T>(T employeeName, string Name, ArrayList arrayList)
        {
            bool isAvailable = false;
            Type employeeType = employeeName.GetType();
            object[] employeeAttributes = employeeType.GetCustomAttributes(false);
            foreach (AccessLevelAttribute employeeAccessLevel in employeeAttributes)
            {
                if (employeeAccessLevel.accessLevel == "programmer" ||
                    employeeAccessLevel.accessLevel == "director")
                    isAvailable = true;
            }
            if (!isAvailable) Console.WriteLine($"Изминение имени пользователям типа {Convert.ToString(employeeName).Replace("Att.", "")} запрещено! Свяжитесь с программистом.");
            if (isAvailable)
            {
                int index = 999;
                bool isFinded = false;
                foreach (var item in arrayList)
                {
                    if ((string)item == Name)
                    {
                        index = arrayList.IndexOf(item);
                        isFinded = true;
                        break;
                    }

                }
                if (isFinded)
                {
                    Console.WriteLine($"Человек {(string)arrayList[index]} удален из листа пользователем типа {Convert.ToString(employeeName).Replace("Att.", "")}.");
                    arrayList.RemoveAt(index);
                }
                else
                {
                    Console.WriteLine($"Человека {Name} не существует в листе.");
                }
            }
        }


        public static void RenamePerson<T>(T employeeName, string Name, string NewName, ArrayList arrayList)
        {
            bool isAvailable = false;
            Type employeeType = employeeName.GetType();
            object[] employeeAttributes = employeeType.GetCustomAttributes(false);
            foreach (AccessLevelAttribute employeeAccessLevel in employeeAttributes)
            {
                if (employeeAccessLevel.accessLevel == "programmer")
                    isAvailable = true;
            }
            if (!isAvailable) Console.WriteLine($"Изминение имени пользователям типа {Convert.ToString(employeeName).Replace("Att.", "")} запрещено! Свяжитесь с программистом.");
            if (isAvailable)
            {
                int index = 999;
                bool isFinded = false;
                foreach (var item in arrayList)
                {
                    if ((string)item == Name)
                    {
                        index = arrayList.IndexOf(item);
                        isFinded = true;
                        break;
                    }
                }
                if (isFinded)
                {
                    Console.WriteLine($"Имя человека изменено из {(string)arrayList[index]} в {(string)NewName} пользователем типа {Convert.ToString(employeeName).Replace("Att.", "")}.");
                    arrayList[index] = NewName;
                }
                else
                {
                    Console.WriteLine($"Человека {Name} не существует в листе.");
                }
            }
        }
    }


    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class AccessLevelAttribute : Attribute
    {
        public string accessLevel { get; set; }
    }

    public class Employee
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            protected set
            {
                name = value;
            }
        }
        public Employee()
        {
            this.name = Name;
        }
    }

    [AccessLevel(accessLevel = "director")]
    public class Director : Employee
    {
        public Director(string name)
        {
            this.Name = name;
        }
    }

    [AccessLevel(accessLevel = "programmer")]
    public class Programmer : Employee
    {
        public Programmer(string name)
        {
            this.Name = name;
        }
    }
    [AccessLevel(accessLevel = "manager")]
    public class Manager : Employee
    {
        public Manager(string name)
        {
            this.Name = name;
        }
    }
}
