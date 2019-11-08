using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace lab13
{
    public static class BAALog
    {
        private static StreamWriter writer = new StreamWriter("baalogfile.txt", true);

        public static void WriteMessage(string message)
        {
            writer.WriteLine(message + ' ' + DateTime.Now.ToString());
        }

        public static void SearchDateDay(string _day)
        {
            string day = _day.Length == 1 ? "0" + _day : _day;
            writer.Close();
            string x, y = "";
            bool space = false;
            StreamReader reader = new StreamReader("baalogfile.txt");
            while (reader.EndOfStream == false)
            {
                x = reader.ReadLine();
                int i = x.Length - 1;
                while (true)
                {
                    if (x[i] == ' ')
                    {
                        if (space == false)
                        {
                            space = true;
                        }
                        else
                        {
                            break;
                        }
                    }

                    y = x[i] + y;
                    i--;
                }
                if (y.Substring(0, 2) == day)
                {
                    Console.WriteLine(x);
                }

                y = "";
                space = false;
            }
            reader.Close();
            writer = new StreamWriter("baalogfile.txt", true);
        }

        public static void SearchPartTime(string parttime)
        {
            DateTime time1, time2, time3;
            int j = 0;
            while (parttime[j] != '-')
            {
                j++;
            }

            time1 = DateTime.Parse(parttime.Substring(0, j));
            time2 = DateTime.Parse(parttime.Substring(j + 1, parttime.Length - j - 1));
            writer.Close();
            string x, y = "";
            StreamReader reader = new StreamReader("baalogfile.txt");
            while (reader.EndOfStream == false)
            {
                x = reader.ReadLine();
                int i = x.Length - 1;
                while (true)
                {
                    if (x[i] == ' ')
                    {
                        break;
                    }
                    y = x[i] + y;
                    i--;
                }
                time3 = DateTime.Parse(y);
                if ((time3 >= time1) && (time3 <= time2))
                {
                    Console.WriteLine(x);
                }

                y = "";
            }
            reader.Close();
            writer = new StreamWriter("baalogfile.txt", true);
        }

        public static void SearchWord(string word)
        {
            writer.Close();
            string x;
            StreamReader reader = new StreamReader("baalogfile.txt");
            while (reader.EndOfStream == false)
            {
                if ((x = reader.ReadLine()).Contains(word) == true)
                {
                    Console.WriteLine(x);
                }
            }

            reader.Close();
            writer = new StreamWriter("baalogfile.txt", true);
        }
        public static void Count()
        {
            writer.Close();
            int count = 0;
            StreamReader reader = new StreamReader("baalogfile.txt");
            while (reader.EndOfStream == false)
            {
                reader.ReadLine();
                count++;
            }
            reader.Close();
            Console.WriteLine("Всего записей: " + count);
            writer = new StreamWriter("baalogfile.txt", true);
        }
        public static void Delete()
        {
            writer.Close();
            DateTime time1, time2, time3;
            time1 = DateTime.Now;
            time2 = time1.AddHours(-1);
            Console.WriteLine(time2.ToShortTimeString());
            int count = 0;
            string x, y = "";
            StreamReader reader = new StreamReader("baalogfile.txt");
            StreamWriter writer1 = new StreamWriter("baalogfiletemp.txt");
            while (reader.EndOfStream == false)
            {
                x = reader.ReadLine();
                int i = x.Length - 1;
                while (true)
                {
                    if (x[i] == ' ')
                    {
                        break;
                    }
                    y = x[i] + y;
                    i--;
                }
                time3 = DateTime.Parse(y);
                if ((time3 >= time2) && (time3 <= time1))
                {
                    writer1.WriteLine(x);
                }

                y = "";
            }
            reader.Close();
            writer1.Close();
            File.Delete("baalogfile.txt");
            File.Move("baalogfiletemp.txt", "baalogfile.txt");
            Console.WriteLine("Всего записей: " + count);
            writer = new StreamWriter("baalogfile.txt", true);
        }
        public static void Close()
        {
            writer.Close();
        }
    }
}
