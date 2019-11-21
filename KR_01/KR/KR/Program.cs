using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR
{
    class Car
    {
        public string Model { get; set; }
        public Car(string _car)
        {
            Model = _car;
        }
        public List<Wheel> wheels = new List<Wheel>();
        public class Wheel
        {
            public string Smth { get; set; }
            public Wheel(string _car)
            {
                Smth = _car;
            }

        }
    }
    public interface ICan
    {
       void Speak();
    }
    public class People
    {
        void Speak()
        {
            Console.WriteLine("Speak from ICan");
        }
    }
    static class Orator
    {
        public static bool Checker(People people)
        {
            if (people is ICan)
            {
                ICan can = people as ICan;
                can.Speak();
                return true;
            }
            else
            {
                Console.WriteLine("No ICan");
                return false;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(System.UInt32.MaxValue);
            string str = Console.ReadLine();
            str = str.Replace("i", "a");
            str = str.Replace("g","j");
            Console.WriteLine(str);
            List<string> list = new List<string>();
            list.Add("1");
            list.Add("2");
            list.Add("3");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Car car = new Car("1");
            car.wheels.Add(new Car.Wheel("1"));
            car.wheels.Add(new Car.Wheel("2"));
            car.wheels.Add(new Car.Wheel("3"));
            car.wheels.Add(new Car.Wheel("4"));
            Car car1 = new Car("2");
            car1.wheels.Add(new Car.Wheel("1"));
            car1.wheels.Add(new Car.Wheel("2"));
            car1.wheels.Add(new Car.Wheel("3"));
            car1.wheels.Add(new Car.Wheel("4"));

           foreach (var item in car.wheels)
            {
                    Console.WriteLine(item.Smth);
            }
            foreach (var item in car1.wheels)
            {
                Console.WriteLine(item.Smth);
            }

                People people = new People();
                Orator.Checker(people);



        }
    }
}
