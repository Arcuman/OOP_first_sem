using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    //abstract class IntelligentCreature
    //{
    //    private int lifelength;
    //    protected int LifeLength
    //    {
    //        get => lifelength;
    //        set => lifelength = value;
    //    }
    //     private int iq;
    //    protected int IQ
    //    {
    //        get => iq;
    //        set => iq = value;
    //    }
    //    protected struct Birthday
    //    {
    //        public int day;
    //        public int month;
    //        public int year;
    //        public Birthday(int _day, int _month, int _year)
    //        {
    //            day = _day;
    //            month = _month;
    //            year = _year;
    //        }
    //    }
    //    abstract public void Think();
    //}
    public interface IIntelligentCreature
    {
        int LifeLength { get;  }
        int IQ { get; }
        string Name { get; }
        void Think();
    }
}
