using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    partial class Car
    {
        public Car():base()
        {
            type = "Машина";
        }
        public Car(string _brand, int _year, int _speed, int _mass, int _powerEngine, int _yearEngine, int _massEngine)
            :base( _brand, _year, _mass,_speed, _powerEngine, _yearEngine, _massEngine)
        {
            type = "Машина";
        }
    }
}
