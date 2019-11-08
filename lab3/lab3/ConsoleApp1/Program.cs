using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public partial class  Table
    {
        public readonly int height;
        
        public int width { get; set; }

        public string color;
        static private int sales ;

        public Table() //a
        {
            height = 10;
            width = 10;
            color = "blue";
            Table.Sales();
        }
        public Table(int h, int w,string c) //b
        {
            height = h;
            width = w;
            color = c;
            Table.Sales();
        }
        static Table() //c
        {
            Console.WriteLine("Static constructor");
        }
        public Table(Table prevtable) //d
        {
            height = prevtable.height;
            width = prevtable.width;
            color = prevtable.color;
            Table.Sales();
        }

        ~Table()
        {
            Console.WriteLine("I am distructor");
        }
        static public int Sales()
        {
            Console.WriteLine(sales);
            return ++sales;
            
        }
        public void PrintTable(string c)
        {
            color = c;
        }
       
    }
    static class OutStatic
    {
        static public void OutStatic1(Table tbl)
        {
            Console.WriteLine(tbl.ToString());
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            
            Table table1 = new Table();
            Console.WriteLine(table1.ToString());
            Table table2 = new Table(110, 210, "red");
            Console.WriteLine(table1.ToString());
                Table table3 = new Table(table2);
            Console.WriteLine(table1.ToString());
                if (table2.Equals(table3))
                    Console.WriteLine("table2 = table3");
                else Console.WriteLine("table2 != table3");
                Console.WriteLine($"Hash table 1 = {table1.GetHashCode()}");
            //table1.height = 100;
            table1.width = 101;
            table1.PrintTable("red");
            Console.WriteLine("{0}", table1.color);
            int a = 5, b = 0;
            Console.WriteLine($"Начальное значение переменной a = {a} b = {b}");
            IncrementVal(ref a , out b);
            Console.WriteLine($"Переменная a после передачи по ссылке равна a = {a} b = {b}");
            OutStatic.OutStatic1(table1);
            var table = new { height = 10, width = 10, color = "red" };
            Console.WriteLine(table.ToString());
            Console.WriteLine(table.GetType());
            Console.WriteLine("----------------------------------------");
            MycCollection<Table> table4 = new MycCollection<Table>();
            table4.addItem(table1);
            table4.addItem(table3);
            table4.printAll();
            Table table5 = new Table(111, 210, "red");
            if (table4.attend(table5))
                Console.WriteLine("True");
            else Console.WriteLine("False");
            MycCollection<Table> table10 = new MycCollection<Table>();
            table10.addItem(table1);
            table10.addItem(table5);
            MycCollection<Table> table6 = table4.Merge(table10);
            Console.WriteLine("table6 = ");
            table6.printAll();
            Singleton<int> singleton = new Singleton<int>();
            singleton.addItem(25);
            singleton.addItem(15);

            Console.WriteLine("\nSingleton : ");
            singleton.printAll();
            Singleton<int> singleton2 = new Singleton<int>();
            Console.WriteLine("\nSingleton2 : ");
            singleton2.printAll();
            singleton.addItem(100);
            Console.WriteLine("\nAfter add to first. The second: ");
            singleton2.printAll();
            Console.ReadLine();
            Console.ReadLine();
        }

        public class MycCollection<T> 
        {
            private T[] items = new T[0];
            public int Count = 0;
            public void addItem(T item)
            {
                Array.Resize(ref items, items.Count() + 1);
                items[items.Count() - 1] = item;
                Count++;
            }
            public void removeItem(T item)
            {
                items[Array.IndexOf(items, item)] = items[items.Count() - 1];
                Array.Resize(ref items, items.Count() - 1);
                Count--;
            }
            public IEnumerable<T> getItems()
            {
                return items;
            }
            public void printAll()
            {
                Console.WriteLine();
                foreach (var oneitem in items)
                {
                    Console.WriteLine(oneitem.ToString());
                }
                Console.WriteLine();
            }
            public bool attend(T item)
            {
                bool rc = false;
                foreach (var oneitem in getItems())
                {
                    if (item.ToString() == oneitem.ToString())
                        rc = true;
                }
                return rc;
            }
            public MycCollection<T> Merge(MycCollection<T> second)
            {
                MycCollection<T> table = new MycCollection<T>();
                foreach (var oneitem in second.getItems())
                {
                    if (!(this.attend(oneitem)))
                        table.addItem(oneitem);
                }
                return table;
            }
        }

        class Singleton<T> : IDisposable
        {

            private static Singleton<T> instance;

            private static T[] items = new T[0];
            public void addItem(T item)
            {
                Array.Resize(ref items, items.Count() + 1);
                items[items.Count() - 1] = item;
            }
            public void removeItem(T item)
            {
                items[Array.IndexOf(items, item)] = items[items.Count() - 1];
                Array.Resize(ref items, items.Count() - 1);
            }
            public IEnumerable<T> getItems()
            {
                return items;
            }
            public Singleton()
            {
            }
            public static Singleton<T> getInstance()
            {
                if (instance == null)
                    instance = new Singleton<T>();
                return instance;
            }
            public void printAll()
            {
                Console.WriteLine();
                foreach (var oneitem in getItems())
                {
                    Console.WriteLine(oneitem);
                }
                Console.WriteLine();
            }
            public void Dispose()
            {
                GC.SuppressFinalize(this);
            }
        }

        static void IncrementVal(ref int x , out int b)
        {
            b = ++x;
        }
    

    }
}