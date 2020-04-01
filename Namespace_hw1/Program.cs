using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Обращение к методу с сборки hw1, входящего в производный класса внешней сборки MyNamespace
 * 
 * Реализация сборки MyNamespace с классом MyClass.
 * Вызов метода реализован в проекте secondProject  (Вызов метода с другой сборки).
 */

namespace hw1
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClassDelivery myClassDelivery = new MyClassDelivery();
            Console.WriteLine("Вызов метода Access сборки MyNamespace реализован в сборке hw1:");
            myClassDelivery.Access();
            Console.ReadKey();
        }
    }

    public class MyClassDelivery : MyNamespace.MyClass
    {
    }
}

namespace MyNamespace
{
    public class MyClass
    {
        public virtual void Access()
        {
            Console.WriteLine("Проект из которого вызван этот метод: " + Environment.NewLine + Directory.GetCurrentDirectory() + Environment.NewLine +
                "Сборка из которой вызван этот метод: " + Environment.NewLine + Assembly.GetEntryAssembly().GetName().Name);
        }
    }
}
