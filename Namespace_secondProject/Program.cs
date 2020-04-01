using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using MyNamespace;

namespace secondProject
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass myClass = new MyClass();
            Console.WriteLine("Текущий проект: " + Environment.NewLine + Directory.GetCurrentDirectory() + Environment.NewLine +
                "Текущая сборки: " + Environment.NewLine + Assembly.GetEntryAssembly().GetName().Name);
            Console.WriteLine();
            myClass.Access();
            Console.ReadKey();
        }
    }
}
