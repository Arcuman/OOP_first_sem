using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Engine
    {
        private int power; //мощность
        private int year; //год изготовления
        private int mass;//масса
        public int Power { get { return power; } }
        public int Year { get { return year; } }
        public int Mass { get { return mass; } }
        public Engine(int _power, int _year, int _mass)
        {
            power = _power;
            year = _year;
            mass = _mass;
        }
        public override string ToString()
        {
            return "Двигатель:\n" +
                   "\tМощность: " + power.ToString() + " лошадиных сил" +
                   "\n\tГод изготовления: " + year.ToString() + " лет" +
                   "\n\tМасса: " + mass.ToString() + " кг";
        }
    }
}
