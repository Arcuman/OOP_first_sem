using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab16
{
    partial class Program
    {
        public static int Rand10()
        {
            Random rand = new Random();
            return rand.Next(10);
        }
        public static int Rand20()
        {
            Random rand = new Random();
            return rand.Next(20);
        }
        public static int Rand30()
        {
            Random rand = new Random();
            return rand.Next(30);
        }
        public static int Avg(int value1, int value2, int value3)
        {
            return (value1 + value2 + value3) / 3;
        }
    }
}
