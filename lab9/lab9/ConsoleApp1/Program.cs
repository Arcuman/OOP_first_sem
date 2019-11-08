using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public delegate void Salary(int sum);
    public delegate void Working();

    internal class Program
    {
        public static void DisplayMessage(int x)
        {
            Console.WriteLine(x.ToString());
        }

        public static StringBuilder RemoveS(StringBuilder str)//удаление знаков
        {
            char[] sign = { '.', ',', '!', '?', '-', ':' };
            for (int i = 0; i < str.Length; i++)
            {
                if (sign.Contains(str[i]))
                {
                    str = str.Remove(i, 1);
                }
            }
            return str;
        }
        public static StringBuilder RemoveSpase(StringBuilder str)//удаление пробелов
        {
            return str.Replace(" ", string.Empty);//возвр. изменённую строку
        }
        public static StringBuilder ToUpper(StringBuilder str)//удаление пробелов
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsLetter(str[i]))
                {
                    str[i] = char.ToUpper(str[i]);
                }
            }
            return str;
        }
        public static StringBuilder ToLower(StringBuilder str)//удаление пробелов
        {
            Console.WriteLine(str.Length);
            for (int i = str.Length - 1; i > str.Length / 2; i--)
            {
                if (char.IsLetter(str[i]))
                {
                    str[i] = char.ToLower(str[i]);
                }
            }
            return str;
        }
        //public static StringBuilder ToUpper(StringBuilder str)//удаление пробелов
        //{
        //    foreach (var s in str)
        //    {
        //    }
        //    return str.Replace(" ", string.Empty);//возвр. изменённую строку
        //}
        private static int Operation(int x, Func<int, int> retF)
        {
            return x < 0 ? 0 : retF(x);
        }

        private static void Main(string[] args)
        {
            Director director = new Director();
            Turners turners = new Turners();
            PartTimeStudents students = new PartTimeStudents();
            Salary salary = DisplayMessage;
            director.SalaryAction += turners.OnDirectorMessage;
            director.WorkAction += turners.OnDirectorMessage;
            director.WorkAction += students.OnDirectorMessage;
            director.Fine(20);
            director.Boost();
            director.Boost();
            director.Fine(20);
         
            StringBuilder Data = new StringBuilder("Это,  предложение! с? пунктуацией.");
            Console.WriteLine(Data);

            Func<StringBuilder, StringBuilder> action;
            action = (str) => str = RemoveS(str);
            action += ((str) => str = RemoveSpase(str));
            action += ((str) => str = ToUpper(str));
            action += ((str) => str = ToLower(str));
            //action +=((str) => str )
            Data = action(Data);
            Console.WriteLine(Data);
            //action = (str) => Console.WriteLine("1"+RemoveS(str));
            //action += (str) => Console.WriteLine("2"+str.ToUpper());
            //action += (str) => Console.WriteLine("3"+str.ToLower());
            //action += (str) => Console.WriteLine("4"+RemoveSpase(str));
            Console.WriteLine(Operation(6, x => x * x));
            foreach (Delegate s in action.GetInvocationList())
            {
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
