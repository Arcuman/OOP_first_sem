using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
     sealed partial class Transformer : Vehicle, IIntelligentCreature,ICarManagment
    {
        private string name;
        public string Name { get { return name; } }
        private bool isCar ;
        public bool IsCar
        {
            get => isCar;
            set => isCar = value;
        }
        private string type;
        public override string Type
        {
            get => type;
        }
        private int lifelength;
        public int LifeLength
        {
            get => lifelength;
        }
        private int iq;
        public int IQ
        {
            get => iq;
        }
        public void Move()
        {
            if(IsCar)
            Console.WriteLine("Двигаемся в форме: " + Type);
            else
            Console.WriteLine("Двигаемся в форме: Человек" );
        }
        public void ChangeForm()
        {
            IsCar = !IsCar;
        }
        public void Think()
        {
            Console.WriteLine("Я думаю железом");
        }
        public void GetMainInfo()
        {
            Console.WriteLine( "Модель: " + Brand + "\nГод: " + Year);
        }
        public override string ToString()
        {
            return "Трансформер:" +
                   "Тип:" + type +
                   "\nИмя: " + Name +
                   "\nМодель: " + Brand +
                   "\nПоявился в ~: " + year.ToString() +
                   "\nСейчас в человекоподобной форме: " + (IsCar ? "Нет" : "Да") +
                   "\nМакс скорость: " + Speed.ToString() +
                   "\nВес: " + Mass.ToString() + " кг" +
                   '\n' + ToConsoleEngine();
        }
    }
}
