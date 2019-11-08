using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    public partial class Human : IIntelligentCreature
    {
        private string name;
        public string Name { get { return name; } }
        private string country;
        public string Country { get { return country; } }
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
        [Serializable]
        struct Birthday
        {
            public int day;
            public int month;
            public int year;
            public Birthday(int _day, int _month, int _year)
            {
                
                day = _day;
                month = _month;
                year = _year;
            }

        }
        private enum HumanSex
        {
            Man = 9,
            Woman 
        };
        private Birthday date;
        public int Day => date.day;
        public int Month => date.month;
        public int Year => date.year;
        private HumanSex sex;
        public string Sex
        {
            get
            {
                if (sex == HumanSex.Man)
                    return "Man";
                if (sex == HumanSex.Woman)
                    return "Woman";
                return "?";
            }
        }
       
        protected string BirthDate()
        {
            if ((date.day == -1) || (date.month == -1) || (date.year == -1))
                return "?:?:?";
            return date.day.ToString() + ':' + date.month.ToString() + ':' + date.year.ToString();
        }
        public void Think()
        {
            Console.WriteLine("Я думаю мозгами");
        }
        public override string ToString()
        {
            return "Человек:\n" +
                   "Продолжительность жизни: " + "~" + LifeLength + " лет" +
                   "\nИмя: " + Name.ToString() +
                   "\nПол: " + Sex.ToString() +
                   "\nГод рождения: " + BirthDate() + "\n";
        }
        public int Met(string name)
        {
            Console.WriteLine("Name " + name);
            return 0;
        }
        public int Met1(string name, int a)
        {
            Console.WriteLine("Name " + name);
            return 0;
        }
        public int Met2(string name , int ab)
        {
            Console.WriteLine("Name " + name);
            return 0;
        }
    }
}
