using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using static System.Console;
namespace lab16
{
    internal partial class Program
    {
        private static void Main(string[] args)
        {
            WriteLine("Задание 1");
            Action action1 = new Action(SieveEratosthenes);
            Stopwatch watch = Stopwatch.StartNew();
            task1 = Task.Factory.StartNew(action1);
            task1.Wait();
            task1.Dispose();
            watch.Stop();
            WriteLine("Time for task: " + watch.Elapsed);



            WriteLine("Задание 2");
            CancellationTokenSource token = new CancellationTokenSource();
            (task1 = new Task(action1, token.Token)).Start();
            token.Cancel();
            WriteLine("Cancel it");


            WriteLine("Задание 3");
            Task<int> rand1 = new Task<int>(Rand10),
                      rand2 = new Task<int>(Rand20),
                      rand3 = new Task<int>(Rand30);
            rand1.Start();
            WriteLine("First Value: " + rand1.Result);
            rand2.Start();
            WriteLine("Second Value: " + rand2.Result);
            rand3.Start();
            WriteLine("Third Value: " + rand3.Result);
            Task<int> avg = new Task<int>(() => Avg(rand1.Result, rand2.Result, rand3.Result));
            avg.Start();
            WriteLine("Average: " + avg.Result);



            WriteLine("Задание 4");
            WriteLine("Continue with chain:");
            Task<int> chain1 = new Task<int>(Rand10);
            Task<int> chain2 = chain1.ContinueWith((task) => Rand20());
            Task<int> chain3 = chain2.ContinueWith((task) => Rand30());
            Task<int> chain4 = chain3.ContinueWith((task) => Avg(chain1.Result, chain2.Result, chain3.Result));
            chain1.Start();
            WriteLine("First Value: " + chain1.Result);
            WriteLine("Second Value: " + chain2.Result);
            WriteLine("Third Value: " + chain3.Result);
            WriteLine("Average: " + chain4.Result);
            chain1.Dispose();
            chain2.Dispose();
            chain3.Dispose();
            chain4.Dispose();

            WriteLine("Awaiter: ");
            Task<int> what = Task.Run(() => Enumerable.Range(1, 100000).Count(n => (n % 2 == 0)));
            TaskAwaiter<int> awaiter = what.GetAwaiter();
            awaiter.OnCompleted(() => { int res = awaiter.GetResult(); WriteLine(res); });



            WriteLine("Задание 5");
            Stopwatch st = new Stopwatch();
            int[] arr1 = new int[10000000];
            int[] arr2 = new int[10000000];
            Random random = new Random();
            st.Restart();
            for (int i = 0; i < arr1.Length; i++)
            {
                arr1[i] = random.Next(0, 300);
                arr2[i] = random.Next(0, 300);
            }
            st.Stop();
            WriteLine("for: " + st.Elapsed);
            st.Restart();
            Parallel.For(0, arr1.Length, i =>
            {
                arr1[i] = random.Next(0, 300);
                arr2[i] = random.Next(0, 300);
            });
            st.Stop();
            WriteLine("ParallelFor: " + st.Elapsed);
            st.Restart();
            Parallel.ForEach<int>(arr1, i =>
            {
                arr1[i] = random.Next(0, 300);
                arr2[i] = random.Next(0, 300);
            });
            st.Stop();
            WriteLine("ParallelForEach: " + st.Elapsed);




            WriteLine("Задание 6");
            Parallel.Invoke(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    WriteLine("perallel1 " + i);
                }

                WriteLine("perallel1 completed");
            },
            () =>
            {
                for (int i = 0; i < 10; i++)
                {
                    WriteLine("perallel2 " + i);
                }

                WriteLine("perallel2 completed");
            });




            WriteLine("Задание 7");
            block = new BlockingCollection<string>(5);
            Task ShopWorkers = new Task(Adding);
            Task Clients = new Task(Selling);
            ShopWorkers.Start();
            Clients.Start();
            Clients.Wait();
            ShopWorkers.Wait();



            WriteLine("Задание 8");
            Async();
            string p = ReadLine();
            WriteLine(p + p + p + "Press any key to end");
            ReadKey();


        }
    }
}
