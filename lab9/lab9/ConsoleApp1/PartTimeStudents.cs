using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class PartTimeStudents
    {
        int count = 50;
        public void OnDirectorMessage() => Console.WriteLine("Один из студентов получил квалификацию токаря. Осталось студентов: " + (--count).ToString());
    }
}
