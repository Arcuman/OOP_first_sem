using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    [Serializable]
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
            iq = _iq;
            country = _country;
            date = new Birthday(_day, _month, _year);
        }
    }
}
