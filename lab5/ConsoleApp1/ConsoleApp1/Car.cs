using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    
    sealed class Car : Vehicle, ICarManagment
    {
        private string brand; //модель 
        private int year; //год изготовления
        private int speed; //год изготовления
        private Engine engine; //двигатель
        public string Brand { get { return brand; } }
        public int Speed { get { return speed; } }
        public int Year { get { return year; } }
        public Engine Engine { get { return engine; } }
        public Car()
        {
            brand = "";
            year = -1;
            Mass = -1;
            speed = -1;
            Price = -1;
            engine = new Engine(-1, -1, -1);
        }
        public Car(string _brand, int _year, int _speed, int _mass, int _price,  int _powerEngine, int _yearEngine, int _massEngine)
        {
            brand = _brand;
            year = _year;
            Mass = _mass;
            speed = _speed;
            Price = _price;
            engine = new Engine(_powerEngine, _yearEngine, _massEngine);
        }
        void ICarManagment.Move() //реалзация интерфейса
        {
            Console.WriteLine("Начинаем движение");
        }
        public override void Move() //переопределение абстрактного метода 
        {
            Console.WriteLine("Двигаемся");
        }

        //public override void Move()
        //{
        //    Console.WriteLine("Двигаемся");
        //}

        public string GetMainInfo()
        {
            return "Модель: " + Brand + "\nГод: " + Year;
        }
        public override void Beep()
        {
            Console.WriteLine("PIIIIP");
        }
        public override string ToString()
        {
            return "Машина:\n" +
                   "\nМодель: " + Brand +
                   "\nГод изготовления: " + year.ToString() +
                   "\nМакс скорость: " + Speed.ToString() +
                   "\nВес: " + Mass.ToString() + " кг" +
                   "\nЦена: " + Price.ToString() + " кг" +
                   '\n' + engine.ToString();
        }
        public override int GetHashCode()
        {
            int sum = 269;
            sum += brand.GetHashCode();
            sum += year.GetHashCode();
            sum += Speed.GetHashCode();
            sum += Price.GetHashCode();
            sum += Mass.GetHashCode();
            return sum;
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType())
                return false;
            if (obj.GetHashCode() != GetHashCode())
                return false;
            return true;
        }
    }
}
