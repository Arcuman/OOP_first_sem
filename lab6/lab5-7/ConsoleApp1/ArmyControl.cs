using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    static class ArmyControl
    {
            
            public static object SearchBirthDate(Army army, int day, int month, int year)
            {
                Console.WriteLine("Searching unit with birthday date " + day + ':' + month + ':' + year + "...");
                bool flag = false;
                object[] arr = army.ListofUnits.ToArray();
                for (int i = 0; i < arr.Length; i++)
                    if (arr[i] is Transformer)
                    {
                        Transformer transformer = arr[i] as Transformer;
                        if (transformer.Year == year)
                            return arr[i];
                    }
                    else
                    {
                        Human human = arr[i] as Human;
                        if ((human.Day == day) && (human.Month == month) && (human.Year == year))
                            return arr[i];
                    }
                if (flag == false)
                    Console.WriteLine("Nothing");
                return "";
            }
            public static void SearchEnginePower(Army army, int power)
            {
                Console.WriteLine("Searching transformer with engine power " + power.ToString() + "...");
                bool flag = false;
                object[] arr = army.ListofUnits.ToArray();
                for (int i = 0; i < arr.Length; i++)
                    if (arr[i] is Transformer)
                    {
                        Transformer transformer = arr[i] as Transformer;
                        if (transformer.PowerEngine == power)
                        {
                            Console.WriteLine((i + 1).ToString() + ' ' + transformer.Name);
                            flag = true;
                        }
                    }
                if (flag == false)
                    Console.WriteLine("Nothing");
            }
            public static int Counts(Army army)
            {
            return army.Count;
            }
        }
    }

