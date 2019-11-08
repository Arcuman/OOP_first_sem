using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Printer
    {
        public virtual void iAmPrinting(ICarManagment someobj)
        {
            Console.WriteLine("Виртуальный метод");
        }
    }
    class A : Printer
    {
        public override void iAmPrinting(ICarManagment someobj)
        {
            Console.WriteLine(someobj.GetType());
            Console.WriteLine(someobj.ToString());
        }
    }
}
