﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace ConsoleApp1
{
    public interface ICollectionType<T> where T : IIntelligentCreature
    {
        void Add(T element);
        void Delete(T element);
        void Show();
    }
    [Serializable]
    public class Set<T> : ICollectionType<T> where T : IIntelligentCreature
    {
        public readonly Owner owner = new Owner(3, "Anton", "BSTU");
        public readonly Date creationDate = new Date();
        public class Owner
        {
            public readonly int id;
            public readonly string name;
            public readonly string organisation;

            public Owner(int id, string name, string organisation)
            {
                this.id = id;
                this.name = name;
                this.organisation = organisation;
            }
            public void Getinfo()
            {
                Console.WriteLine($"ID: {id} Name: {name} Organization: {organisation}");
            }
        }
        public class Date
        {
            DateTime dateTime = DateTime.Now;

            public override String ToString()
            {
                return dateTime.ToShortDateString();
            }
        }


        private List<T> _items = new List<T>();

        public int Count => _items.Count;

        public void Add(T item)
        {
            if (!_items.Contains(item))
            {
                _items.Add(item);
            }
        }


        public void Delete(T item)
        {
            _items.Remove(item);
        }

        public static Set<T> Union(Set<T> set1, Set<T> set2)
        {
            var resultSet = new Set<T>();

            var items = new List<T>();
            if (set1._items != null && set1._items.Count > 0)
            {
                items.AddRange(new List<T>(set1._items));
            }
            if (set2._items != null && set2._items.Count > 0)
            {
                items.AddRange(new List<T>(set2._items));
            }
            resultSet._items = items.Distinct().ToList();
            return resultSet;
        }

        public static Set<T> Intersection(Set<T> set1, Set<T> set2) //пересечение и
        {
            var resultSet = new Set<T>();

            if (set1.Count < set2.Count)
            {
                foreach (var item in set1._items)
                {
                    if (set2._items.Contains(item))
                    {
                        resultSet.Add(item);
                    }
                }
            }
            else
            {
                foreach (var item in set2._items)
                {
                    if (set1._items.Contains(item))
                    {
                        resultSet.Add(item);
                    }
                }
            }
            return resultSet;
        }

        public static Set<T> Difference(Set<T> set1, Set<T> set2) //разность А\В
        {
            var resultSet = new Set<T>();

            foreach (var item in set1._items)
            {
                if (!set2._items.Contains(item))
                {
                    resultSet.Add(item);
                }
            }

            foreach (var item in set2._items)
            {
                if (!set1._items.Contains(item))
                {
                    resultSet.Add(item);
                }
            }
            resultSet._items = resultSet._items.Distinct().ToList();
            return resultSet;
        }


        public static bool Subset(Set<T> set1, Set<T> set2)
        {
            bool result = set1._items.All(s => set2._items.Contains(s));
            return result;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        public void Show()
        {
            foreach (T str in this)
            {
                Console.Write(str + " ");
            }
            Console.WriteLine();
        }

        public static Set<T> operator +(Set<T> list, T item)
        {
            list.Add(item);
            return list;
        }
        public static Set<T> operator +(Set<T> list1, Set<T> list2)
        {
            var resultSum = new Set<T>();
            resultSum = Set<T>.Union(list1, list2);
            return resultSum;
        }
        public static Set<T> operator *(Set<T> list1, Set<T> list2)
        {
            var resultSum = new Set<T>();
            resultSum = Set<T>.Intersection(list1, list2);
            return resultSum;
        }
        public static explicit operator int(Set<T> list1)
        {
            return list1.Count;
        }
        // Перегружаем оператор false
        public static bool operator false(Set<T> obj)
        {
            if (obj.Count < 6 && obj.Count > 1)
                return true;
            return false;
        }

        // Обязательно перегружаем оператор true
        public static bool operator true(Set<T> obj)
        {
            if (obj.Count > 6 || obj.Count < 1)
                return true;
            return false;
        }

        public void Save(string CurrentFile)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream(CurrentFile, FileMode.OpenOrCreate))
            {
                bf.Serialize(fs, _items);
                fs.Close();
            }
        }

        public void Upload(string CurrentFile)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream(CurrentFile, FileMode.OpenOrCreate))
            {
                List<T> deser = (List<T>)bf.Deserialize(fs);
                foreach (T p in deser)
                {
                    if (p == null)
                        continue;
                    this.Add(p);
                }
                fs.Close();
            }
        }
    }
}
