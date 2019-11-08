using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
     class Human : IntelligentCreature
    {
        private string sex;
        private int age;
        public Human()
        {
            LifeLength = 100;
            sex = "";
            age = -1;
            Name = "";
        }
        public Human(string _sex, int _age, string _name)
        {
            LifeLength = 100;
            sex = _sex;
            age = _age;
            Name = _name;
        }
        public string Sex => sex;
        public int Age
        {
            get => age;
            set => age = value;
        }
        public virtual void Look()
        {
            Console.WriteLine("Смотрю глазами");
        }
        public override string ToString()
        {
            return "Человек:\n" +
                   "Продолжительность жизни: " + "~" + LifeLength + " лет" +
                   "\nИмя: " + Name.ToString() +
                   "\nПол: " + sex.ToString() +
                   "\nВозвраст: " + age.ToString() + " лет";
        }
    }
}
