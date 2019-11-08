using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

        sealed partial class Car : Vehicle, ICarManagment
    {
        private string type;
        public override string Type
        {
            get => type;
        }
        void ICarManagment.Move() //явная реалзация интерфейса
        {
            Console.WriteLine("Начинаем движение");
        }

        public void GetMainInfo()
        {
            Console.WriteLine( "Модель: " + Brand + "\nГод: " + Year);
        }        
        public override string ToString()
        {
            return "Тип:" + type +
                   "\nМодель: " + Brand +
                   "\nГод изготовления: " + year.ToString() +
                   "\nМакс скорость: " + Speed.ToString() +
                   "\nВес: " + Mass.ToString() + " кг" +
                   '\n' + ToConsoleEngine();
        }
        public override int GetHashCode()
        {
            int sum = 269;
            sum += brand.GetHashCode();
            sum += year.GetHashCode();
            sum += Speed.GetHashCode();
            sum += type.GetHashCode();
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
