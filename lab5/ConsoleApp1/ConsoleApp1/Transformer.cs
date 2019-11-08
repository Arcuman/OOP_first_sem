using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
     sealed class Transformer :Human, ITransformer
    {
        private string brand; //модель 
        private string name; //модель 
        private int year; //год изготовления
        private int speed; //год изготовления
        private Engine engine; //двигатель
        new public string Name { get { return name; }  }
        public string Brand { get { return brand; } }
        public int Year { get { return year; } }
        public int Speed { get { return speed; } }
        public Engine Engine { get { return engine; } }

        public Transformer(string _brand, string _name, int _year, int _speed, int _powerEngine, int _yearEngine, int _massEngine)
        {
            LifeLength = 1000;
            brand = _brand;
            year = _year;
            speed = _speed;
            name = _name;
            engine = new Engine(_powerEngine, _yearEngine, _massEngine);
        }
        void ICarManagment.Move() //реалзация интерфейса
        {
            Console.WriteLine("Р-о-о-б-о-т стартовал");
        }
        string ICarManagment.GetMainInfo() //реалзация интерфейса
        {
            return "Модель: " + Brand + "\nГод: " + Year;
        }
        public override void Look()
        {
            Console.WriteLine("Чувствую схемами");
        }
        public override string ToString()
        {
            return "Трансформер:" +
                   "\nИмя: " + Name +
                   "\nМодель: " + Brand +
                   "\nПоявился в ~: " + year.ToString() +
                   "\nМакс скорость: " + Speed.ToString() +
                   '\n' + engine.ToString();
        }
    }
}
