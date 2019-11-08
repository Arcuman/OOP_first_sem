using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Reflector reflector = new Reflector("ConsoleApp11.Human");
            reflector.AboutClass();
            reflector.PublicMethods();
            reflector.Fields();
            reflector.Interfaces();
            reflector.Methods();
            reflector.Runtimemethod("Met");

            Reflector reflector1 = new Reflector("ConsoleApp11.IIntelligentCreature");
            reflector1.AboutClass();
            reflector1.PublicMethods();
            reflector1.Fields();
            reflector1.Interfaces();
            reflector1.Methods();
            string str = "as";
            Reflector reflector2 = new Reflector(str.GetType());
            reflector2.AboutClass();
            reflector2.PublicMethods();
            reflector2.Fields();
            reflector2.Interfaces();
            reflector2.Methods();
        }
    }
}
