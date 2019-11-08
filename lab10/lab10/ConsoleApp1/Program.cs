using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
namespace ConsoleApp1
{
    class Engine : IComparable<Engine>
    {
        private int powerEngine; //мощность
        private int yearEngine; //год изготовления
        private int massEngine;//масса
        public int PowerEngine { get { return powerEngine; } }
        public int YearEngine { get { return yearEngine; } }
        public int MassEngine { get { return massEngine; } }
        public int CompareTo(Engine _engine)
        {
            if (this.powerEngine > _engine.powerEngine)
                return 1;
            else if (this.powerEngine < _engine.powerEngine)
                return -1;
            else return 0;
        }
        public Engine(int _power = -1, int _year = -1, int _mass = -1)
        {
            powerEngine = _power;
            yearEngine = _year;
            massEngine = _mass;
        }
        public override string ToString()
        {
            return "Двигатель:\n" +
                   "\tМощность: " + powerEngine.ToString() + " лошадиных сил" +
                   "\n\tГод изготовления: " + yearEngine.ToString() + " лет" +
                   "\n\tМасса: " + massEngine.ToString() + " кг";
        }
        public override int GetHashCode()
        {
            int sum = 269;
            sum += powerEngine.GetHashCode();
            sum += yearEngine.GetHashCode();
            sum += massEngine.GetHashCode();
            return sum;
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType())
                return false;
            if (obj.GetHashCode() != GetHashCode())
                return false;
            return true;
        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            ArrayList array = new ArrayList(100);
            for (int i = 0; i < 3; i++)
                array.Add(random.Next(0,10));
            array.Add(2);
            array.Add(3);
            array.Remove(3);
            array.Add("hello");
            Console.WriteLine("ArrayList count: " + array.Count.ToString() + "\nArrayList:");
           
            for (int i = 0; i < array.Count; i++)
                Console.WriteLine(array[i].ToString());
            int temp = array.IndexOf("hello");
            if (temp != -1)
                Console.WriteLine("Индекс первого вхождения слова hello: " + temp);
            else
                Console.WriteLine("Элемент не найден");
            Console.WriteLine("_____________________________");
            HashSet<long> hash = new HashSet<long>();
            hash.Add(1);
            hash.Add(2);
            hash.Add(3);
            hash.Add(4);
            hash.Add(5);
            hash.Add(6);
            hash.Add(7);
            hash.Add(8);
            Console.WriteLine("HashSet элементы:");
            foreach (long x in hash)
                Console.WriteLine(x.ToString());
            for (int i = 0; i < 3; i++)
            {
                hash.Remove(hash.ElementAt(0));
            }
            Console.WriteLine("_____________________________");
            hash.Add(9);
            hash.Add(10);
            hash.Add(11);
            hash.Add(12);
            foreach (long x in hash)
                Console.WriteLine(x.ToString());
            Console.WriteLine("_____________________________");
            LinkedList<long> list = new LinkedList<long>(hash);
            Console.WriteLine();
            Console.WriteLine("LinkedList элементы:");
            foreach (long x in list)
                Console.WriteLine(x.ToString());
            Console.WriteLine("_____________________________");
            LinkedListNode<long> list1 = list.Find(12);
            Console.WriteLine("Value: " + list1.Value.ToString());
            Console.WriteLine("Next: " + list1.Next?.Value.ToString());
            Console.WriteLine("Previous: " + list1.Previous?.Value.ToString());

            HashSet<Engine> hash1 = new HashSet<Engine>();
            Engine engine = new Engine(5, 150, 320);
            hash1.Add(new Engine(1, 100, 200));
            hash1.Add(new Engine(10, 10, 200));
            hash1.Add(new Engine(0, 1000, 201));
            hash1.Add(new Engine(2, 110, 202));
            hash1.Add(new Engine(3, 102, 220));
            hash1.Add(new Engine(4, 200, 222));
            hash1.Add(engine);
            hash1.Add(new Engine(6, 190, 290));
            Console.WriteLine("HashSet elements:");
            foreach (Engine x in hash1)
                Console.WriteLine(x.ToString());
            for (int i = 0; i < 3; i++)
            {
                hash1.Remove(hash1.ElementAt(0));
            }
            Console.WriteLine("_____________________________");
            hash1.Add(new Engine(12, 220, 122));
            hash1.Add(new Engine(14, 256, 327));
            hash1.Add(new Engine(8, 132, 232));
            hash1.Add(new Engine(7, 201, 272));
            foreach (Engine x in hash1)
                Console.WriteLine(x.ToString());
            Console.WriteLine("____________________________");
            LinkedList<Engine> engine1 = new LinkedList<Engine>(hash1);
            Console.WriteLine();
            Console.WriteLine("LinkedList элементы:");
            foreach (Engine x in engine1)
                Console.WriteLine(x.ToString());
            LinkedListNode<Engine> list2 = engine1.Find(new Engine(7, 201, 272));
            Console.WriteLine("Value: " + list2?.Value.ToString());
            Console.WriteLine("Next: " + list2?.Next?.Value.ToString());
            Console.WriteLine("Previous: " + list2?.Previous?.Value.ToString());

            Console.WriteLine("____________________________");
            ObservableCollection<Engine> _engines = new ObservableCollection<Engine>
            {
               new Engine(1, 100, 100),
               new Engine(2, 200, 200),
               new Engine(3, 300, 300),
            };
            _engines.CollectionChanged += Users_CollectionChanged;
            _engines.Add(new Engine(4, 400, 400));
            _engines.RemoveAt(1);

            Console.ReadKey();

        }
        private static void Users_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add: // если добавление
                    Engine newUser = e.NewItems[0] as Engine;
                    Console.WriteLine($"Добавлен новый объект: {newUser.PowerEngine}");
                    break;
                case NotifyCollectionChangedAction.Remove: // если удаление
                    Engine oldUser = e.OldItems[0] as Engine;
                    Console.WriteLine($"Удален объект: {oldUser.PowerEngine}");
                    break;
            }
        }
    }
}
