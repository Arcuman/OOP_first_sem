using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab13
{
    internal static class BAADiskInfo
    {
        private static readonly DriveInfo[] AllDisk = DriveInfo.GetDrives();

        public static void FreeSpace(string name)
        {
            BAALog.WriteMessage("Метод для вывода информации о свободном месте на диске: " + name );
            Console.WriteLine(name);
            name = name + ":\\";
            Console.WriteLine(name);
            foreach (DriveInfo disk in AllDisk)
            {
                if (disk.Name == name)
                {
                    Console.WriteLine($"Name disk:{disk.Name}");
                    if (disk.IsReady)
                    {
                        Console.WriteLine($"Free space: {disk.TotalFreeSpace / 1024 / 1024 / 1024} ГБ\n");
                    }
                }
            }
        }
        public static void DisInfo()
        {
            BAALog.WriteMessage("Метод для вывода информации о дисках компьютера: ");
            foreach (DriveInfo disk in AllDisk)
            {
                Console.WriteLine($"Name disk:{disk.Name}");
                if (disk.IsReady)
                {
                    Console.WriteLine($"Total size: {disk.TotalSize / 1024 / 1024 / 1024} ГБ");
                    Console.WriteLine($"Free space: {disk.TotalFreeSpace / 1024 / 1024 / 1024} ГБ");
                    Console.WriteLine($"FileSystem:{disk.RootDirectory}");
                    Console.WriteLine($"VolumeLabel:{disk.VolumeLabel}");
                    Console.WriteLine($"DriveType:{disk.DriveType}\n");
                }
            }
        }
    }
}
