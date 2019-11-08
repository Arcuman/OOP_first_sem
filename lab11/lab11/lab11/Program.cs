using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11
{
    class Program
    {
        static void Main(string[] args)
        {
            #region First
            string[] month = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "November", "December" };
            string[] WinSumMounth = { "January", "February", "December", "June", "July", "August" };
            Console.WriteLine($" Введите n:");
            int n = int.Parse(Console.ReadLine());
            var strLength = from t in month // определяем каждый объект из month как t
                            where t.Length == n //фильтрация по критерию
                            select t; // выбираем объект
            //var strLength = month.Where(t => t.Length == n);
            Console.WriteLine($"Строки с длиной строки n = {n}");
            foreach (string s in strLength)
                Console.WriteLine(s);
            var strWinSum = from t in month
                            where WinSumMounth.Contains(t)
                            select t;
            //var strWinSum = month.Where(t => WinSumMounth.Contains(t));
            Console.WriteLine($"Зимнии и летнии месяца:");
            foreach (string s in strWinSum)
                Console.WriteLine(s);
            var strOrderBy = from t in month
                             orderby t
                             select t;
            //var strOrderBy = month.OrderBy(t => t);
            Console.WriteLine($"Вывод в алфавитном порядке:");
            foreach (string s in strOrderBy)
                Console.WriteLine(s);
            int strCount = (from t in month
                            where t.Contains("u") && t.Length > 4
                            select t).Count();
            //int strCount = month.Where(t => t.Contains("u") && t.Length > 4).Count();
            Console.WriteLine($"Количество месяцев содержащих u и длиной строки > 4 :");
            Console.WriteLine(strCount);
            #endregion
            #region Second + Third
            Console.WriteLine($"________________________________________________________");
            Console.WriteLine($"Задание 2-3: ");
            List<Set<int>> tables = new List<Set<int>>();
            Set<int> a1 = new Set<int>();
            a1.Add(-1); a1.Add(2); a1.Add(3); a1.Add(4); a1.Add(5); a1.Add(6); a1.Add(7); a1.Add(8);
            Set<int> a2 = new Set<int>();
            a2.Add(10); a2.Add(20); a2.Add(30); a2.Add(40); a2.Add(50); a2.Add(60); a2.Add(8);
            Set<int> a3 = new Set<int>();
            a3.Add(100); a3.Add(200); a3.Add(300); a3.Add(400); a3.Add(500); a3.Add(600);
            tables.Add(a1); tables.Add(a2); tables.Add(a3);
            foreach (var s in tables)
                foreach (var t in s)
                    Console.WriteLine(t);
            var task1sum = from t in tables
                           select t.Sum();
            int max = task1sum.Max();
            var set1 = from t in tables
                       where t.Sum() == max
                       select t;
            Console.WriteLine($" Множества c наибольшей суммой элементов: {max} \n:");
            foreach (var s in set1)
                foreach (var t in s)
                {
                    Console.WriteLine(t);
                }
            var set2 = from set in tables
                       where set.IsHaveNeg()
                       select set;
            //var set2 = tables.Where(set => set.IsHaveNeg());
            Console.WriteLine($" Множества содержащие отрицательные элементы:");
            foreach (var s in set2)
                foreach (var t in s)
                {
                    Console.WriteLine(t);
                }
            Console.WriteLine($"Введите элемент:");
            int m = int.Parse(Console.ReadLine());
            var set3 = from set in tables
                       where set.IsContain(m)
                       select set;
            Console.WriteLine($" Множества содержащие введеное число m: {m}");
            foreach (var s in set3)
                foreach (var t in s)
                {
                    Console.WriteLine(t);
                }
            var set4 = tables.Max();
            Console.WriteLine($"Макимальное множество: ");
            foreach (var s in set4)
                Console.WriteLine(s);
            var set5 = tables.First(set => set.IsContain(m));
            Console.WriteLine($" Первое множества содержащие введеное число m: {m}");
            foreach (var s in set5)
                Console.WriteLine(s);
            var set6 = from set in tables
                       orderby set.GetFirst()
                       select set;
            Console.WriteLine($"Отсортированный массив множеств:");
            foreach (var s in set6)
                foreach (var t in s)
                    Console.WriteLine(t);
            //#endregion
            #region Fourth

            List<Player> players = new List<Player>() {   new Player {Name="Месси", Team="Барселона"},
                                                         new Player {Name="Неймар", Team="Барселона"},
                                                           new Player {Name="Роббен", Team="Бавария"}
                                                                                                };
            var temp1 = from player in players
                        where player.Team == "Барселона"
                        orderby player.Name
                        group player by player.Team;

            foreach (IGrouping<string, Player> g in temp1)
            {
                Console.WriteLine(g.Key);
                foreach (var t in g)
                    Console.WriteLine(t.Name);
                Console.WriteLine();
            }

            #endregion
            #region Fifth
            List<Team> teams = new List<Team>() { new Team { Name = "Бавария", Country ="Германия" },
                                                 new Team { Name = "Барселона", Country ="Испания" }
            };
            //var result = from pl in players
            //             join t in teams on pl.Team equals t.Name
            //             select new { Name = pl.Name, Team = pl.Team, Country = t.Country };
            var result = players.Join(teams, p => p.Team, t => t.Name, (p, t) => new { Name = p.Name, Team = p.Team ,Country = t.Country });
            foreach (var item in result)
                Console.WriteLine($"{item.Name} - {item.Team} ({item.Country})");
            #endregion
            Console.ReadKey();
            #endregion
        }
    }
}
