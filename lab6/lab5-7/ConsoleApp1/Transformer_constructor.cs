using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    partial class Transformer
    {
        public Transformer():base()
        {
            lifelength = 1000;
            type = "";
        }
        public Transformer(string _type, string _brand, string _name , int _year, int _speed, int _mass, int _iq ,int _powerEngine, int _yearEngine, int _massEngine)
          : base(_brand, _year, _mass, _speed, _powerEngine, _yearEngine, _massEngine)
        {
            lifelength = 1000;
            type = _type;
            name = _name;
            iq = _iq;
            IsCar = true;
        }
    }
}
