using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Turners
    {
        private int count = 50;
        private int salary = 100;
        public void OnDirectorMessage(int x) => Console.WriteLine("С зарплаты будет вычтен штраф в размере " + x.ToString() + "$. Ожидаемая зарплата: " + (salary -= x).ToString() + "$");
        public void OnDirectorMessage() => Console.WriteLine("Один из токарей получил повышение. Осталось работников: " + (--count).ToString());
    }
}
