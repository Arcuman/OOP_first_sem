using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    
        class Program
        {
        static void Main(string[] args)
        {
            try
            {
                Set<int> myList1 = new Set<int>();
                for (int i = 0; i < 15; i++)
                {
                    myList1.Add(i);
                }
                myList1.Show();
                Set<int> myList2 = new Set<int>();
                for (int i = 3; i < 8; i++)
                {
                    myList2.Add(i);
                }
                myList2.Show();
                myList2 += 10;
                myList2.Show();
                Set<int> myList3 = new Set<int>();
                myList3 = myList2 + myList1;
                myList3.Show();
                myList3 = myList2 * myList1;
                myList3.Show();
                int a = (int)myList1;
                Console.WriteLine(a);
                if (myList1)
                    Console.WriteLine("true");
                else
                    Console.WriteLine("false");
                myList1.owner.Getinfo();
                Console.WriteLine(myList1.creationDate.ToString());

                Console.WriteLine($"Макс элем {StaticOperation.GetMaxElement(myList1)}");
                Console.WriteLine($"Мин элем {StaticOperation.GetMinElement(myList1)}");
                string testString = "one two three";
                Console.WriteLine(testString.Common());
                myList1.DeleteTheSame(14);
                myList1.Show();
            }
            catch
            {
                Console.WriteLine("Ошибка");
            }
            finally
            {
                Console.WriteLine("Finally block");
            }
            Console.ReadKey();
        }
        }
}
