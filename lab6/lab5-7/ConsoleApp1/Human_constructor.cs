using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    
    public partial class Human
    {
        public Human()
        {
            lifelength = 100;
            sex = 0;
            date = new Birthday(-1, -1, -1);
            iq = 0;
            name = "";
        }
        public Human(string _name, int _sex, int _age, string _country, int _day, int _month, int _year , int _iq)
        {
            lifelength = 100;
            if (_sex == 1)
                sex = HumanSex.Man;
            else if (_sex == 2)
                sex = HumanSex.Woman;
            else throw new CreatingClassException(this, sex.GetType()); ;
            iq = _iq;
            name = _name ?? throw new CreatingClassException(this); 
            country = _country;
            if (_day < 1 || _day > 31) throw new CreatingClassException(this, _day.GetType());
            if (_month < 1 || _month > 12) throw new CreatingClassException(this, _day.GetType());
            if (_year < 1) throw new CreatingClassException(this, _day.GetType());
            date = new Birthday(_day, _month, _year);
        }
    }
}
