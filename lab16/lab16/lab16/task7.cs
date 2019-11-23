using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Concurrent;
namespace lab16
{
    partial class Program
    {
        public static BlockingCollection<string> block;
        public static void Adding()
        {
            Random r = new Random();
            int x;
            List<string> products = new List<string>() { "Микроволновка", "Холодильник", "Мультиварка", "Пылесос", "Плита" };
            for (int i = 0; i < 5; i++)
            {
                x = r.Next(0, products.Count - 1);
                Console.WriteLine("Добавлен товар: " + products[x]);
                block.Add(products[x]);
                products.RemoveAt(x);
                Thread.Sleep(r.Next(1, 3));
            }
            block.CompleteAdding();
        }
        public static void Selling()
        {
            string str;
            while (block.IsAddingCompleted == false)
            {
                if (block.TryTake(out str) == true)
                    Console.WriteLine("Был куплен товар: " + str);
                else Console.WriteLine("Покупатель ушел");
            }
        }
    }
}
