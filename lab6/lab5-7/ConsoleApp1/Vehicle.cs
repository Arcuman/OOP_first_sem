using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    abstract class Vehicle:Engine
    {
        protected Vehicle()
            :base()
        {
            brand = "";
            year = -1;
            Mass = -1;
            speed = -1;
        }
        protected Vehicle(string _brand, int _year,int _mass,int _speed, int _powerEngine, int _yearEngine, int _massEngine)
            :base( _powerEngine,  _yearEngine,  _massEngine)
        {
            brand = _brand ?? throw new CreatingClassException(this);
            if (_year < 0) throw new CreatingClassException(this, _year.GetType());
            if (_mass < 0) throw new CreatingClassException(this, _mass.GetType());
            if (_speed < 0) throw new CreatingClassException(this, _speed.GetType());
            year = _year;
            Mass = _mass;
            speed = _speed;
        }
        protected int speed;  //Скорость
        protected int Speed
        {
            get => speed;
            set => speed = value;
        }
        protected int mass;      //вес
        protected int Mass
        {
            get => mass;
            set => mass = value;
        }
        protected int year ;
        public int Year
        {
            get => year;
            set => year = value;
        }
        protected string brand;
        protected string Brand
        {
            get => brand;
            set => brand = value;
        }
        abstract public string Type { get; }
    }
}
