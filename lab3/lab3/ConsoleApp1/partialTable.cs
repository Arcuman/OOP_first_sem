using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public partial class  Table
    {
        public override string ToString()
        {
            string str = String.Format("Высота: {0}  Ширина: {1} Цвет: {2} Количество проданых столов {3}", height, width, color, sales);
            return str;
        }

        public bool Equals(Table table1)
        {
            if (table1.height == height && table1.width == width && table1.color == color)
                return true;
            else return false;
        }
        public override int GetHashCode()
        {
            int hash = height.GetHashCode() + width.GetHashCode() + color.GetHashCode();
            return hash;
        }
    }
}
