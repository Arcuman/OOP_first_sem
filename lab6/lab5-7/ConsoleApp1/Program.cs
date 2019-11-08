using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            #region
            Car car1 = new Car("toyota", 2010, 180, 3000, 800, 2010, 100);
            Car car12 = new Car("AUDI", 2011, 300, 3250, 1100, 2009, 600);
            ICarManagment car2 = new Car("toyota", 2010, 300, 3000, 900, 2008, 700);
            Vehicle vehicle;
            vehicle = car12 as Vehicle;

            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Вывод созданных объектов");
            Console.WriteLine(vehicle.ToString());
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine(car1.ToString());
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine(car2.ToString());
            Console.WriteLine("------------------------------------------------");

            ICarManagment car;
            //car.Move(); не присвоено значение
            car = car1 as ICarManagment;
            //car1.Move(); //не содержит метода Move
            Console.WriteLine("Демонстрация движения машины и вывод информации");
            car.Move();
            car2.Move();
            car2.GetMainInfo();
            Console.WriteLine("------------------------------------------------");

            Human human1 = new Human("Anton", 1, 18, "Belarus", 3, 1, 2001, 130);
            Human human2 = new Human("Vlad", 1, 18, "Belarus", 9, 2, 2001, 130);
            Transformer transformer1 = new Transformer("Car", "Bamblbee", "BMW", 1985, 300, 4385, 125, 749, 2001, 800);
            ICarManagment transformer2 = new Transformer("Car", "Optimus1", "МАЗ", 1093, 320, 1500, 154, 749, 2013, 720);
            IIntelligentCreature creature1;
            creature1 = human1 as IIntelligentCreature;
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Вывод созданных объектов");
            Console.WriteLine(human1.ToString());
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine(creature1.ToString());
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine(transformer1.ToString());
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine(transformer2.ToString());
            Console.WriteLine("------------------------------------------------");


            Console.WriteLine("Демонстрация движения трансформера и вывод информации");
            transformer1.Move();
            transformer1.ChangeForm();
            transformer1.Move();
            transformer1.GetMainInfo();

            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Как думает трансфомер и человек");
            creature1 = transformer2 as IIntelligentCreature;
            human1.Think();
            creature1.Think();
            Console.WriteLine("------------------------------------------------");
            ICarManagment[] arr = { car2, transformer2 };

            Printer printer = new Printer();
            Printer printerA = new A();
            printer.iAmPrinting(arr[0]);
            Console.WriteLine("------------------------------------------------");
            for (int i = 0; i < arr.Length; i++)
            {
                printerA.iAmPrinting(arr[i]);
                Console.WriteLine("------------------------------------------------");
            }

            Army army1 = new Army();
            army1.Add(human1);
            army1.Add(human2);
            army1.Add(transformer1);
            army1.Add(transformer2);
            Console.WriteLine("-1-----------------------------------------------");
            Console.WriteLine("-1-----------------------------------------------");
            Console.WriteLine("-1-----------------------------------------------");
            army1.ToConsole();
            //army1.ListofUnits[0] = transformer1;
            Console.WriteLine(army1.ListofUnits[0].GetType());
            Console.WriteLine("-1-----------------------------------------------");
            Console.WriteLine(human1.GetType());
            object temp = human1;
            Console.WriteLine(temp.GetType());
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine(ArmyControl.SearchBirthDate(army1, 3, 1, 2001));
            ArmyControl.SearchEnginePower(army1, 749);
            try
            {
                Human humanExeption = new Human("Vlad", 1, 18, "Belarus", 90, 2, 2, 130); //дата
            }
            catch (CreatingClassException exception)
            {
                Console.WriteLine(exception.GetMessage);
                Console.WriteLine(exception.StackTrace);
                Console.WriteLine("Класс который вызвал ошибку: " + exception.Source);
                Console.WriteLine("Тип поля которое вызвало ошибку: " + exception.WhatData);
            }
            Console.WriteLine("------------------------------------------------");
            try
            {
                Human humanExeption = new Human(null, 1, 18, "Belarus", 90, 2, 2, 130); //дата
            }
            catch (CreatingClassException exception)
            {
                Console.WriteLine(exception.GetMessage);
                Console.WriteLine(exception.StackTrace);
                Console.WriteLine("Класс который вызвал ошибку: " + exception.Source);
                Console.WriteLine("Тип поля которое вызвало ошибку: " + exception.WhatData);
            }
            Console.WriteLine("------------------------------------------------");
            try
            {
                int[] arr1 = { 1, 2, 3 };
                int i = -4;
                if (i > arr1.Length || i < 0)
                {
                    throw new OutofRangeException(i, arr1.Length);
                }
                else
                {
                    Console.WriteLine(arr[i].ToString());
                }
            }
            catch (OutofRangeException exception)
            {
                Console.WriteLine(exception.GetMessage);
                Console.WriteLine(exception.StackTrace);
                Console.WriteLine("Вышло за пределы типа на значение: " + exception.OutValue.ToString());
                Console.WriteLine("Вышло за пределы массива на значение: " + exception.OutRange.ToString());
            }
            Console.WriteLine("------------------------------------------------");
            try
            {
                long i = 200;
                long x = i + int.MaxValue;
                if (x > int.MaxValue || x < int.MinValue)
                {
                    throw new OutofRangeException(x);
                }
            }
            catch (OutofRangeException exception)
            {
                Console.WriteLine(exception.GetMessage);
                Console.WriteLine(exception.StackTrace);
                Console.WriteLine("Вышло за пределы типа на значение: " + exception.OutValue.ToString());
                Console.WriteLine("Вышло за пределы массива на значение: " + exception.OutRange.ToString());
            }
            Console.WriteLine("------------------------------------------------");
            try
            {
                int x = 10;
                int y = 0;
                int result = (y == 0) ? throw new ArithmeticException() : x / y;
            }
            catch (ArithmeticException exception)
            {
                Console.WriteLine(exception.GetMessage);
                Console.WriteLine(exception.StackTrace);
            }
            Console.WriteLine("------------------------------------------------");
            try
            {
                int x = 0;
                int y = 10 / x;
            }
            catch
            {
                Console.WriteLine("Вызвано исключение");
            }
            finally
            {
                Console.WriteLine("Обработка ошибок завершена");
            }
            Console.WriteLine("------------------------------------------------");
            int[] aa = null;
            Debug.Assert(aa == null, "Values array cannot be null");
            #endregion
            Set<IIntelligentCreature> myList1 = new Set<IIntelligentCreature>();
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Lab8");
            myList1.Add(human1);
            myList1.Add(human2);
            myList1.Show();
            myList1.Save(@"..\..\class.dat");
            Console.WriteLine("------------------------------------------------");
            myList1.Delete(human2);
            myList1.Delete(human1);
            myList1.Show();
            myList1.Upload(@"..\..\class.dat");
            myList1.Show();
            Console.ReadKey();
        }
    }
}
