using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw1
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass myClass = new MyClass();
            myClass.MyMethod();
            myClass.MyErrorMethod();
            Console.ReadKey();
        }
    }

    class MyClass : Attribute
    {
        //Вывод в предупреждение
        [Obsolete("Вывод на экран не обезательный")]
        public void MyMethod()
        {
            Console.WriteLine("Проверка связи...");
        }

        //Ошибки при компиляции
        [Obsolete("Исправить", true)]
        public void MyErrorMethod()
        {
            Console.WriteLine("Проверка связи не сработает...");
        }
    }
}
