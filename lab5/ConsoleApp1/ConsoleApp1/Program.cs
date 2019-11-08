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
            Vehicle vehicle;
            Car car1 = new Car("toyota",2010, 300, 3000, 150000, 900, 2008, 700);
            Car car12 = new Car("AUDI", 2011, 400, 3250, 170000, 1100, 2009, 600);
            ICarManagment car2 = new Car("toyota", 2010, 300, 3000, 150000, 900, 2008, 700);
            vehicle = car1 as Vehicle;
            IntelligentCreature creature1;
            Human human1 = new Human("man", 18,"Anton");
            creature1 = human1 as IntelligentCreature;
            Transformer transformer1 = new Transformer("BMW","Optimus",1000,3000,1500,1968,800);
            ITransformer transformer2 = new Transformer("BMW1", "Optimus1", 10001, 30001, 15001, 19681, 8001);
            car1.Move();
            car2.Move();
            vehicle.Beep();
            Console.WriteLine(vehicle.ToString());
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine(car1.ToString());
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine(car2.ToString());
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine(human1.ToString());
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine(creature1.ToString());
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine(transformer1.ToString());
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine(transformer2.ToString());
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine(transformer2.GetMainInfo());
            transformer2.Move();
            Human humantrans = new Transformer("BMW2", "Optimus2", 10002, 30002, 15002, 19682, 8002);
            human1.Look();
            humantrans.Look();
            Console.WriteLine("------------------------------------------------");
            ICarManagment[] arr = { car2, transformer2 };
            Printer printer = new Printer();
            for (int i = 0; i < arr.Length; i++)
            {
                printer.iAmPrinting(arr[i]);
                Console.WriteLine("------------------------------------------------");
            }
            //car2.GetCarMark();
            Console.ReadKey();
        }
    }
}
