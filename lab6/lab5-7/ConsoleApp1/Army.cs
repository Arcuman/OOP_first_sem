using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Army
    {
        private List<object> units = new List<object>();
        public int Count => units.Count;
        public List<object> ListofUnits
        {
            get => units;
            set => units = value;
        }
        public void Add(Human human)
        {
            object x = human;
            units.Add(x);
        }
        public void Add(Transformer transformer)
        {
            object x = transformer;
            units.Add(x);
        }
        public void Add(ICarManagment transformer)
        {
            object x = transformer;
            units.Add(x);
        }
        public void Remove(Human human)
        {
            object x = human;
            units.Remove(x);
        }
        public void Remove(Transformer transformer)
        {
            object x = transformer;
            units.Remove(x);
        }
        public void Remove(ICarManagment transformer)
        {
            object x = transformer;
            units.Remove(x);
        }
        public void ToConsole()
        {
            object[] arr = units.ToArray();
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine((i + 1).ToString() + ' ' + arr[i].ToString() + '\n');
            }
        }
    }
}
