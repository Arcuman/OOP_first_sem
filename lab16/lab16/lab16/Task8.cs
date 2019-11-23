using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace lab16
{
    partial class Program
    {
        public static void ForAsync()
        {
            for (int i = 0; i < 30; i++)
                if (i % 3 == 0)
                {
                    Console.Write(i + ", ");
                    Thread.Sleep(1000);
                }
        }
        public static async void Async()
        {
            Console.WriteLine("Async function start:");
            await Task.Run(() => ForAsync());
            Console.WriteLine("Async function completed");
        }
    }
}
