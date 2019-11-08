using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
namespace lab13
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            BAADiskInfo.FreeSpace("C");
            BAADiskInfo.DisInfo();
            BAAFileInfo file = new BAAFileInfo(@"D:\БГТУ 2 курс\OOP\Лабы\lab13\lab13\lab13test.txt");
            BAADirInfo dir = new BAADirInfo(@"D:\БГТУ 2 курс\OOP\Лабы\lab13\lab13");
            file.Path();
            dir.DirInfo();
            BAAFileManager.FileSubdir("D:\\");
            BAAFileManager.CreateA();
            BAAFileManager.CreateB();
            BAAFileManager.CreateC();
            BAALog.SearchWord("файле");
            BAALog.SearchDateDay("21");
            BAALog.SearchPartTime("22:00-23:00");
            BAALog.Count();
            BAALog.Delete();
            BAALog.Close();
            Console.ReadKey();
        }
    }
}
