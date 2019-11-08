using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    interface ICarManagment
    {
        void Move();
        string Brand { get; } //модель
        int Year { get; }     //год изготовления
        int Speed { get; }     //скорость
        Engine Engine { get; } //двигатель 
        string GetMainInfo();
    }
    interface ITransformer : ICarManagment
    {
        string Name { get; }
    }
}
