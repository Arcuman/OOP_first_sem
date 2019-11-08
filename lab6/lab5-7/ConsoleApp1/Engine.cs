using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Engine
    {
        private int powerEngine; //мощность
        private int yearEngine; //год изготовления
        private int massEngine;//масса
        public int PowerEngine { get { return powerEngine; } }
        public int YearEngine { get { return yearEngine; } }
        public int MassEngine { get { return massEngine; } }
        public Engine(int _power, int _year, int _mass)
        {
            if (_power < 0 ) throw new CreatingClassException(this, _power.GetType());
            if (_power < 0 ) throw new CreatingClassException(this, _year.GetType());
            if (_power < 0) throw new CreatingClassException(this, _mass.GetType());
            powerEngine = _power;
            yearEngine = _year;
            massEngine = _mass;
        }
        public Engine()
        {
            powerEngine = -1;
            yearEngine = -1;
            massEngine = -1;
        }
        public  string ToConsoleEngine()
        {
            return "Двигатель:\n" +
                   "\tМощность: " + powerEngine.ToString() + " лошадиных сил" +
                   "\n\tГод изготовления: " + yearEngine.ToString() + " лет" +
                   "\n\tМасса: " + massEngine.ToString() + " кг";
        }
        public override string ToString()
        {
            return "Двигатель:\n" +
                   "\tМощность: " + powerEngine.ToString() + " лошадиных сил" +
                   "\n\tГод изготовления: " + yearEngine.ToString() + " лет" +
                   "\n\tМасса: " + massEngine.ToString() + " кг";
        }
    }
}
