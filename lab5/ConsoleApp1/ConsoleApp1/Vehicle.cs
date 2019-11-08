using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    abstract class Vehicle
    {

        private int speed;  //Скорость
        protected int Speed
        {
            get => speed;
            set => speed = value;
        }
        private int mass;      //вес
        protected int Mass
        {
            get => mass;
            set => mass = value;
        }
        private int price;     //цена
        protected int Price 
        {
            get => price;
            set => price = value;
        }
        public abstract void Move();
        public abstract void Beep();
        
    }
}
